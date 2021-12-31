using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControls : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

}
// This is  comment AND i chnaged it. 