using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public GameObject owner;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject != owner)
        {
            Destroy(gameObject);
        }
        
    }
}