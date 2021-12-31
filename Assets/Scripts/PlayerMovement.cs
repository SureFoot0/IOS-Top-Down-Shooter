using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float autoSpeed = 0.5f;

    public Rigidbody2D rb;

    public Camera cam;

    Vector2 movement;

    Vector2 mousePos;

    public Transform firePoint;
    public GameObject BulletPrefab;
    public Transform targetPoint;
    public GameObject TargetPrefab;

    public float bulletForce = 20f;

    public float bulletCooldown = 0f;

    void Update()
    {
        movement.x = mousePos.x;
        movement.y = mousePos.y;
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            mousePos = cam.ScreenToWorldPoint(touch.position);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
        }
        
        bulletCooldown -= 1;

        
        
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
