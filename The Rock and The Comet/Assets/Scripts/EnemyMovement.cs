using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    private float direction;
    private Rigidbody2D enemybody;
    private Vector3 flip;

    // Start is called before the first frame update
    private void Start()
    {
       flip = transform.localScale;
       enemybody = GetComponent<Rigidbody2D>();
       direction = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="ground"){ //enemy changes direction when it hits a wall
            direction *= -1; //reverse direction
            flip *= -1; //changing the scale by a negative number flips the sprite
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemybody.velocity = new Vector2(direction * speed, enemybody.velocity.y);
    }
}
