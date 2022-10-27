using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpStrength = 1;
    [SerializeField] float maxJumps = 1;

    private int currentJumps = 0;
    private Rigidbody2D rb;
    public bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //handles horizontal movement
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

        //if jumps are left and the player is on the ground jump
        if (isGrounded && maxJumps > currentJumps)
        {
            rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * jumpStrength), ForceMode2D.Impulse);
        }
    }

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
            currentJumps--;
        }
    }
}
