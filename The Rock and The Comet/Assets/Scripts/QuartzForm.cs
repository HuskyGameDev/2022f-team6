using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach this script to the player game object
public class QuartzForm : MonoBehaviour
{
    private Movement movement;
    private FormSwitching formSwitching;

    //grab the components off the player
    private void Start()
    {
        movement = this.GetComponent<Movement>();
        formSwitching = this.GetComponent<FormSwitching>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (formSwitching.inQuartz)
        {
            movement.setGrounded(true);
        }
    }
}
