using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //for respawn and related menu functionality 
    private Transform spawnPoint;
    private Transform playerPos;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] GameObject playerUI;

    //set in editor
    [SerializeField] int maxHp = 3;

    //set this as max hp decreasing then sparkle max hp decreasing in the editor (should be 6 sprites)
    [SerializeField] Sprite[] healthSprites;

    //set this as the ui element that is the healthbar image
    [SerializeField] Image healthBar;

    //locally keeps track of hp since no other scripts use it at the moment
    private int currentHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        //finds the object tagged as player and accesses the transform
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
       //finds the object tagged as respawn and accesses the transform
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        currentHp = maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the player touches an enemy or healing object or checkpoint and performs the appropriate modification to hp
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
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            //transform of the collider object for code brevity in the next lines
            Transform coll = collision.gameObject.transform;
            //sets spawnpoint to the location of the checkpoint just reached
            spawnPoint.position = new Vector3(coll.position.x, coll.position.y, coll.position.z);
            //destroys object with the collider so player can move through the checkpoint
            Destroy(collision.gameObject);
            Debug.Log("X: " + spawnPoint.position.x + "Y: " + spawnPoint.position.y);
            Debug.Log("touched checkpoint");
    
        }
    }

    private void FixedUpdate()
    {
        //may want to move this into where hp is actually updated for performance, but this is easier for now
        updateHealthBar(currentHp);

        //checks if the players hp hits zero and destroys the player object if it does
        if (currentHp <= 0)
        {
            //pulls up the death message
            deathScreen();
            //respawns player and puts back in the original spawn point
            
            
            //Destroy(gameObject);
        }
    }

    //makes sure the healthbar shows the correct ammount of hp (will later add to make sparkle when hp changes)
    private void updateHealthBar(int hp)
    {
        if(hp == 3)
        {
            healthBar.sprite = healthSprites[0];
        } else if(hp == 2)
        {
            healthBar.sprite = healthSprites[1];
        } else if(hp == 1)
        {
            healthBar.sprite = healthSprites[2];
        } 
        else if(hp <= 0)
        {
            //player died
            Debug.Log("player died");
        }
        
    }

    private void deathScreen()
    {
        Time.timeScale = 0;
        deathCanvas.SetActive(true);
        playerUI.SetActive(false);
    }

    public void Respawn()
    {
        Time.timeScale = 1;
        deathCanvas.SetActive(false);
        playerUI.SetActive(true);
        playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Debug.Log("X: " + spawnPoint.position.x + "Y: " + spawnPoint.position.y);
        currentHp = 3;
    }
}