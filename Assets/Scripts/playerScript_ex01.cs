using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class playerScript_ex01 : MonoBehaviour
{
    public static playerScript_ex01 ActivePlayer { get; private set; }

    [SerializeField] private bool defaultPlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private KeyCode key;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (defaultPlayer)
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

        var velocity = _rigidbody2D.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = moveSpeed;
        }
        else
        {
            velocity.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            velocity.y = jumpPower;
            _isGrounded = false;
        }
        _rigidbody2D.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contactCount > 0 && other.contacts[0].normal.y > 0.8f)
        {
            _isGrounded = true;
        }    
    }
}