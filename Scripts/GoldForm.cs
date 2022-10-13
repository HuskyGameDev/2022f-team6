using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldForm : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Gold"))
        {
            //shrink the player
            if (collision.gameObject.CompareTag("shrink"))
            {
                gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            }
            else

            //grow the player
            if (collision.gameObject.CompareTag("grow"))
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else //allows player to grow outside of gold, this prevents them from being trapped small if they change forms
        {
            if (collision.gameObject.CompareTag("grow"))
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            Debug.Log("gold not active");
        }
    }
    
}
