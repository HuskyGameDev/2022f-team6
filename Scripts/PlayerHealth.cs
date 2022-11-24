using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //set in editor
    [SerializeField] int maxHp = 3;

    //locally keeps track of hp since no other scripts use it at the moment
    private int currentHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the player touches an enemy or healing object and performs the appropriate modification to hp
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp--;
        }
        else if (collision.gameObject.CompareTag("Heal") && currentHp < maxHp)
        {
            currentHp++;

            //destroys the healing object (I'm going under 1x use assumption)
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //checks if the players hp hits zero and destroys the player object if it does
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
