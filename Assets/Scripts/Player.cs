using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] Rigidbody2D rigid;

    private bool isGrounded = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float HAxis = Input.GetAxisRaw("Horizontal");
        rigid.linearVelocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rigid.linearVelocity.y);

        if (isGrounded) 
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float length = 0.55f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, length, layerMask);
            isGrounded = hit;
        }
    }
}
