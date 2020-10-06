using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }
}
