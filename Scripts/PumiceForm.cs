using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumiceForm : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the player is in pumice mode and coliding with a object tagged water make them float
        if (CompareTag("Pumice"))
        {
            if (collision.gameObject.CompareTag("water"))
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = -.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when the player exits a water object make gravity normal (disables floating)
        if (collision.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
