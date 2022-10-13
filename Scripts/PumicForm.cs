using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumicForm : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
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
        if (collision.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
