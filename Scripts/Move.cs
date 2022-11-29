using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //these are meant to be edited in the unity editor, tweak them as you please
    [SerializeField] float speed = 1;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] float jumpStrength = 1;
    [SerializeField] float maxJumps = 1;
    [SerializeField] float jumpTimer = 1f;

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
        /*
         * this timer is to prevent "multi jumps" since this is a frame based movement without a timer you can get multiple
         * jumps in at a time and it creates some weird/unpredictible behavior (get weird flight without this)
        */
        currentJumpTimer -= Time.fixedDeltaTime;

        //handles horizontal movement (the if statments are to cap move speeds)
        if (rb.velocity.x > -maxSpeed && Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        }
        else if (rb.velocity.x < maxSpeed && Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        }

        //handles jumps by adding force when key is clicked and starting a timer (as well as keeping track of jumps)
        if (Input.GetAxis("Jump") > 0 && isGrounded && maxJumps > currentJumps && currentJumpTimer <= 0)
        {
            rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            currentJumps++;
            currentJumpTimer = jumpTimer;
        }
    }

    //checks if the player is on the ground
    #region isGrounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
    #endregion
}
