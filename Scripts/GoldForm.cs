using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldForm : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //shrink the player
        if (collision.gameObject.CompareTag("shrink"))
        {
            gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        } else

        //grow the player
        if (collision.gameObject.CompareTag("grow"))
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
