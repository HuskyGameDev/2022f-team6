using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //these are meant to be edited in the unity editor, tweak them as you please
    [SerializeField] float speed = 1;
    [SerializeField] float defaultMaxSpeed = 1;
    [SerializeField] float jumpStrength = 1;
    [SerializeField] float maxJumps = 1;
    [SerializeField] bool unlimitedJump = true;
    [SerializeField] float jumpTimer = 1f;
    [SerializeField] float frictionStrength = 1f;

    //should be safe to ignore these, used by functions below to keep track of various info
    private int currentJumps = 0;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float currentJumpTimer = 0f;

    private bool useVertLimit = false;
    private float maxVertSpeed = 1f;
    private float maxSpeed = 1f;

    //using a setter for this to keep it more contained/traceable
    #region setters and getters
    public void setGrounded(bool val)
    {
        isGrounded = val;

        if(val)
            currentJumpTimer = jumpTimer;
    }

    //sets a custom verticle speed or if given no input returns to default speed limit (none in this case)
    public void setVertSpeedLimit(float speed)
    {
        useVertLimit = true;
        maxVertSpeed = speed;
    }
    public void setVertSpeedLimit()
    {
        useVertLimit = false;
    }

    //sets a custom horizontal speed or if given no input returns to default speed limit
    public void setHorizontalLimit(float speed)
    {
        maxSpeed = speed;
    }
    public void setHorizontalLimit()
    {
        maxSpeed = defaultMaxSpeed;
    }
    #endregion setters and getters



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = defaultMaxSpeed;
    }

    private void FixedUpdate()
    {
        //allows for coyote jump
        if (!isGrounded)
            currentJumpTimer -= Time.fixedDeltaTime;

        //if player isn't attempting to move horizontally apply custom friction
        else if (Input.GetAxis("Horizontal") == 0)
            rb.velocity -= new Vector2(rb.velocity.x * Time.deltaTime * frictionStrength, 0);

        //handles horizontal movement
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
    }

    private void Update()
    {
        //handles jumps by adding force when key is clicked and starting a timer (as well as keeping track of jumps)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && (maxJumps > currentJumps || unlimitedJump) && currentJumpTimer > 0.0000)
        {
            rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);

            currentJumps++;
            currentJumpTimer = jumpTimer;
            isGrounded = false;
        }

        //apply verticle speed limit if appropriate (currently used by pumice form)
        if (useVertLimit)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxVertSpeed, maxVertSpeed));
    }

    //handles player jump timer with being grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            setGrounded(true);
    }

    //updates when player is no longer touching an object (has redundancy in jump function incase player is touching an object not tagged with ground)
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    #region use these methods to get information for other scripts

    public bool movingHorizontal()
    {
        if (Mathf.Abs(rb.velocity.x) > 0)
            return true;
        else
            return false;
    }

    public bool movingVerticle()
    {
        if (Mathf.Abs(rb.velocity.y) > 0)
            return true;
        else
            return false;
    }

    public bool checkGrounded()
    {
        return isGrounded;
    }

    #endregion
}
