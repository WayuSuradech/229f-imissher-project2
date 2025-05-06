using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    public float speed = 2f;
    private bool movingRight = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // เดินไปข้างหน้าเรื่อย ๆ ตามทิศ
        rb.velocity = new Vector2(movingRight ? speed : -speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ถ้าชนกับกำแพงหรือวัตถุอื่น ให้หันกลับ
        if (collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }
    void Flip()
    {
        movingRight = !movingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

