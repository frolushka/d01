using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class playerScript_ex00 : MonoBehaviour
{
    public static playerScript_ex00 ActivePlayer { get; private set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private KeyCode key;

    private Rigidbody2D _rigidbody2D;

    // private float _currentVerticalVelocity;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (!ActivePlayer)
        {
            ActivePlayer = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            ActivePlayer = this;
        }

        if (ActivePlayer != this)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        var moveDirection = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1;
        }

        if (!Mathf.Approximately(moveDirection, 0))
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + Time.deltaTime * moveSpeed * moveDirection * Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var velocity = _rigidbody2D.velocity;
            velocity.y = jumpPower;
            _rigidbody2D.velocity = velocity * Time.fixedDeltaTime;
        }
    }
}
