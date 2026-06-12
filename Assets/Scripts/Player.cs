using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] private Animator animator;

    private bool isGrounded = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float HAxis = Input.GetAxisRaw("Horizontal");
        rigid.linearVelocity = new Vector2(speed * HAxis, rigid.linearVelocity.y);

        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(speed * HAxis));
        }

        if (HAxis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (HAxis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

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

            if (isGrounded)
            {
                if (animator != null)
                {
                    animator.SetTrigger("Jump");
                }
            }
        }
    }
}
