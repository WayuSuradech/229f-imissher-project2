using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    private bool facingRight = false;
    private Vector2 moveInput;
    private Rigidbody2D rb2d;
    
    [Header("Sounds")]
    public AudioSource audioSource;       
    public AudioClip coinSound; 

    [Header("Coin")]
    public int coinsCounter = 0;
    public Text coinText;

    [Header("UI")]
    public GameObject finishPanel;
    public Text levelCoinText;
    public Text totalCoinText;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        finishPanel.SetActive(false);
    }
    
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
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
         
            PlayerPrefs.DeleteKey("TotalCoin");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.CompareTag("Enemy1"))
        {
            
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCounter += 1;
            PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 1);
            Destroy(other.gameObject);
            
            if (audioSource != null && coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0f; 
            finishPanel.SetActive(true); 
            levelCoinText.text = "Your Coin In This Map is " + coinsCounter;
            totalCoinText.text = "Total Coin: " + PlayerPrefs.GetInt("TotalCoin", 0);
        }
    }
}
