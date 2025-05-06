using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    private float move;
    public float JumpForce;
    public bool IsJumping;
    public int coinsCounter = 0;
    public Text coinText;
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
       coinText.text = coinsCounter.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ชนศัตรู! เริ่มเกมใหม่...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCounter += 1;
            Destroy(other.gameObject);
        }
    }
}
