using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedPlayerHealth : MonoBehaviour
{

    //for respawn functionality 
    private Transform spawnPoint;
    private Transform playerPos;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] GameObject playerUI;
    public Map map;
    public LevelSwitcher switcher;

    //set in editor
    [SerializeField] int maxHp = 3;

    //set this as max hp decreasing then sparkle max hp decreasing in the editor (should be 6 sprites)
    //[SerializeField] Sprite[] healthSprites;
    public Animator animator;

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

        animator.SetBool("No Damage", true);
        animator.SetBool("1 Damage", false);
        animator.SetBool("2 Damage", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the player touches an enemy or healing object or checkpoint and performs the appropriate modification to hp
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // We want the player to be able to pass through checkpoints and healing mushrooms
        // So change the collision entry to be trigger entry instead
        if (collision.gameObject.CompareTag("Heal") && currentHp < maxHp)
        {
            currentHp++;

            //destroys the healing object (I'm going under 1x use assumption)
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = collision.gameObject.transform;
        }
        else if (collision.gameObject.CompareTag("Room"))
        {
            map.newRoom(collision);
        }
        else if (collision.gameObject.name == "Caves2 Collider")
        {
            switcher.caves2();
        }
        else if (collision.gameObject.name == "Caves1 Collider")
        {
            switcher.caves1();
        }
        else if (collision.gameObject.name == "CrystalCaves Collider" || collision.gameObject.name == "CrystalCaves Collider (1)")
        {
            switcher.crystalCaves();
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
            
            //Destroy(gameObject);
        }
    }

    //makes sure the healthbar shows the correct ammount of hp (will later add to make sparkle when hp changes)
    private void updateHealthBar(int hp)
    {
        if(hp == 3)
        {
            //healthBar.sprite = healthSprites[0];
            animator.SetBool("No Damage", true);
            animator.SetBool("1 Damage", false);
            animator.SetBool("2 Damage", false);
        } else if(hp == 2)
        {
            //healthBar.sprite = healthSprites[1];
            animator.SetBool("No Damage", false);
            animator.SetBool("1 Damage", true);
            animator.SetBool("2 Damage", false);
        } else if(hp == 1)
        {
            //healthBar.sprite = healthSprites[2];
            animator.SetBool("No Damage", false);
            animator.SetBool("1 Damage", false);
            animator.SetBool("2 Damage", true);
        } else if(hp <= 0)
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
        // The respawn bounce is a little annoying, but that is because we have frozen time after bouncing
        // If we don't stop time, there is no bounce, but the player continues to move during the respawn menu
        Time.timeScale = 1;
        deathCanvas.SetActive(false);
        playerUI.SetActive(true);
        
        //respawns player and puts back in the original spawn point
        currentHp = 3;
        playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Debug.Log("X: " + spawnPoint.position.x + "Y: " + spawnPoint.position.y);
        animator.SetBool("No Damage", true);
        animator.SetBool("1 Damage", false);
        animator.SetBool("2 Damage", false);
    }
}
