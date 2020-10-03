using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pauseDuration;
    [SerializeField] private Transform[] targets;

    private int _currentTargetIndex;
    private Rigidbody2D _rigidbody2D;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        var delay = new WaitForSeconds(pauseDuration);

        while (true)
        {
            var targetPosition = targets[_currentTargetIndex].position;
            var newPosition = Vector2.MoveTowards(_rigidbody2D.position, targetPosition, speed * Time.deltaTime);
            _rigidbody2D.MovePosition(newPosition);

            if (Mathf.Approximately(newPosition.x, targetPosition.x) && Mathf.Approximately(newPosition.y, targetPosition.y))
            {
                _currentTargetIndex = (_currentTargetIndex + 1) % targets.Length;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
}
