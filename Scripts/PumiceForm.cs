using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumiceForm : MonoBehaviour
{
    [SerializeField] float normalGravity = 1;
    [SerializeField] float floatStrength = .5f;
    //TODO: probably should integrate this with the form switching script

    private void FixedUpdate()
    {
        //if the player exits pumice form set gravity back to normal
        if(!CompareTag("Pumice"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
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
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when the player exits a water object make gravity normal (disables floating)
        if (collision.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
        }
    }
}
