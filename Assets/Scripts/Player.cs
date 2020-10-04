using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    
    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contactCount > 0 && other.contacts[0].normal.y > 0.8f)
        {
            _isGrounded = true;
        }    
    }

    public void Move(float direction)
    {
        var velocity = _rigidbody2D.velocity;
        if (direction > 0)
        {
            velocity.x = moveSpeed;     
        }
        else if (direction < 0)
        {
            velocity.x = -moveSpeed;
        }
        else
        {
            velocity.x = 0;
        }
        _rigidbody2D.velocity = velocity;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            
            var velocity = _rigidbody2D.velocity;
            velocity.y = jumpPower;
            _rigidbody2D.velocity = velocity;
        }
    }
}
