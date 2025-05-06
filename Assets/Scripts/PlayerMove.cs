using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    private float move;
    public float JumpForce;
    public bool IsJumping;
    private bool facingRight = false;
    Rigidbody2D rb2d;
    Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButton("Horizontal"))
       {
           moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
           rb2d.AddForce(moveInput * Speed);
       }
       
       if (Input.GetButtonDown("Jump")&& !IsJumping) 
       {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
       }
       if (!facingRight && moveInput.x > 0)
       {
            Flip();
       }
       else if (facingRight && moveInput.x < 0)
       {
            Flip();
       }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
