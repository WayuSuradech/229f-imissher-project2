using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform shootpoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletPrefab;
    
    public AudioSource audioSource;        
    public AudioClip shootSound;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                Vector2 projectileVelocity = CalculateProjectileVelocity(shootpoint.position, hit.point, 0.35f);
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootpoint.position, Quaternion.identity);
                shootBullet.linearVelocity = projectileVelocity;
                
                if (audioSource != null && shootSound != null)
                {
                    audioSource.PlayOneShot(shootSound);
                }
            }
        }
    }
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
        return projectileVelocity;
    }

}
