using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 3;

    //used to move the player in a direction when they hit an enemy
    [SerializeField] float xOffset = 0;
    [SerializeField] float yOffset = 0;

    private int currentHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp--;
            gameObject.transform.position += new Vector3(xOffset, yOffset);
        } else if(collision.gameObject.CompareTag("Heal") && currentHp < maxHp)
        {
            currentHp++;
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
