using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float ForceValue = 15;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.AddForce(new Vector2(Input.acceleration.x * ForceValue, Input.acceleration.y * ForceValue));
    }
}
