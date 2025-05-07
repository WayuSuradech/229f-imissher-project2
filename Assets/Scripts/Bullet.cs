using System;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour

{
    public AudioClip enemyHitSound;   // ใส่เสียงจาก Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // เล่นเสียง
            if (audioSource != null && enemyHitSound != null)
            {
                audioSource.PlayOneShot(enemyHitSound);
            }

          
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerMove playerScript = player.GetComponent<PlayerMove>();
                if (playerScript != null)
                {
                    playerScript.coinsCounter += 3;
                }
            }
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
