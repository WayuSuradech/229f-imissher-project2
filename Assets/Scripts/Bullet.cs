using System;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour

{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // หาผู้เล่นเพื่อเพิ่มเหรียญ
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerMove playerScript = player.GetComponent<PlayerMove>(); // เปลี่ยนชื่อคลาสให้ตรงของคุณ
                if (playerScript != null)
                {
                    playerScript.coinsCounter += 3;
                }
            }

            Destroy(collision.gameObject); // ทำลาย Enemy
            Destroy(gameObject);           // ทำลาย Bullet
        }
    }
}
