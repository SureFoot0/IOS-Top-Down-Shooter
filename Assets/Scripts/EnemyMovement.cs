using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float autoSpeed = 0.5f;

    public Rigidbody2D rb;

    Vector2 movement;
    
    Vector2 mousePos;

    public Transform firePoint;
    public Transform Player;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;
    public float TankForce = 0.005f;
    public float bulletCooldown = 0f;

    void Update()
    {
        mousePos = Player.position;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.AddForce(firePoint.up * TankForce, ForceMode2D.Impulse);
        
        bulletCooldown -= 1;
        Shoot();
        
        
    }

    public void Shoot()
    {
        if (bulletCooldown < 0) {
            GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bulletCooldown = 500;
        }
        else {
            bulletCooldown -= 1;
        }
    }
}
