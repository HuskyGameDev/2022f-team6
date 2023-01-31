using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //these are meant to be edited in the unity editor, tweak them as you please
    [SerializeField] float speed = 1;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] float jumpStrength = 1;
    [SerializeField] float maxJumps = 1;
    [SerializeField] float jumpTimer = 1f;
    [SerializeField] float frictionStrength = 1f;

    //should be safe to ignore these, used by functions below to keep track of various info
    private int currentJumps = 0;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float currentJumpTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        //allows for coyote jump
        if (!isGrounded)
        {
            currentJumpTimer -= Time.fixedDeltaTime;
        }
        else if(Input.GetAxis("Horizontal") == 0)
        {
            //if player is on ground slow horizontal movement
            rb.velocity -= new Vector2(rb.velocity.x * Time.deltaTime * frictionStrength, 0);
        }

        //handles horizontal movement
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
    }

    private void Update()
    {
        //handles jumps by adding force when key is clicked and starting a timer (as well as keeping track of jumps)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && maxJumps > currentJumps && currentJumpTimer > 0.0000)
        {
            rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            currentJumps++;
            currentJumpTimer = jumpTimer;
            isGrounded = false;
        }
    }

    //handles player jump timer with being grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            currentJumpTimer = jumpTimer;
            isGrounded = true;
        }
    }
}
