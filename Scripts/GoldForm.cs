using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldForm : MonoBehaviour
{
    public float minScale = 1f;
    public float normScale = 2f;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Gold"))
        {
            //shrink the player
            if (collision.gameObject.CompareTag("shrink"))
            {
                gameObject.transform.localScale = new Vector3(minScale, minScale, minScale);
            }
            else

            //grow the player
            if (collision.gameObject.CompareTag("grow"))
            {
                gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
            }
        }
        else //allows player to grow outside of gold, this prevents them from being trapped small if they change forms
        {
            if (collision.gameObject.CompareTag("grow"))
            {
                gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
            }
            Debug.Log("gold not active");
        }
    }
    
}
