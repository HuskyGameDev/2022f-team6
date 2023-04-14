using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumiceForm : MonoBehaviour
{
    [SerializeField] float normalGravity = 1;
    [SerializeField] float floatStrength = .5f;
    [SerializeField] float ascendSpeedLimit = 1f;
    [SerializeField] float horizontalSwimSpeed = 1f;
    //TODO: probably should integrate this with the form switching script

    private Movement movement;

    //get the move componenet of this game object
    private void Start()
    {
        //movement is not properly being assigned a value -- causing null reference exceptions
        movement = this.GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        //if the player exits pumice form set gravity back to normal
        if(!CompareTag("Pumice"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
            movement.setVertSpeedLimit();
            movement.setHorizontalLimit();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the player is in pumice mode and coliding with a object tagged water make them float
        if (CompareTag("Pumice"))
        {
            if (collision.gameObject.CompareTag("water"))
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = -floatStrength;
                movement.setVertSpeedLimit(ascendSpeedLimit);
                movement.setHorizontalLimit(horizontalSwimSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when the player exits a water object make gravity normal (disables floating)
        if (collision.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
            movement.setVertSpeedLimit();

            //consider putting a timer here to fix the quick speed up as you bounce out, or reduce horizontal speed
            movement.setHorizontalLimit();
        }
    }
}
