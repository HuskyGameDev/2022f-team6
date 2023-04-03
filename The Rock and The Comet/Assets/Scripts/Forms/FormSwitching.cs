using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormSwitching : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool inGold = false;
    public bool inPum = false;
    public bool inQuartz = false;
    public bool inNone = true;
    /**KEY
     1 = Gold form
    2 = Pummice form
    3 = Quartz form */

    //locks all forms by default
    public bool goldUnlocked = false;
    public bool pumiceUnlocked = false;
    public bool quartzUnlocked = false;

    //get all the sprites from the editor
    [SerializeField] Sprite basic;
    [SerializeField] Sprite gold;
    [SerializeField] Sprite goldSquish;
    [SerializeField] Sprite quartz;
    [SerializeField] Sprite pumice;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player touches a powerup object...
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            //checks which powerup it is, unlocks corresponding form
            if(collision.gameObject.name == "Gold Powerup")
            {
                goldUnlocked = true;
            }
            else if(collision.gameObject.name =="Pumice Powerup")
            {
                pumiceUnlocked = true;
            }
            else if(collision.gameObject.name == "Quartz Powerup")
            {
                quartzUnlocked = true;
            }
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //handles switching to and from gold form
        if (Input.GetKeyDown(KeyCode.Alpha1) && !inGold && goldUnlocked)
        {
            player.tag = "Gold";
            inGold = true;
            inPum = false;
            inQuartz = false;
            inNone = false;

            //changes sprite
            sr.sprite = gold;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && inGold)
        {
            player.tag = "Player";
            inGold = false;

            //changes sprite
            sr.sprite = basic;
            inNone = true;
        }

        //handles switching to and from pumice form
        if(Input.GetKeyDown(KeyCode.Alpha2) && !inPum && pumiceUnlocked)
        {
            player.tag = "Pumice";
            inPum = true;
            inGold = false;
            inQuartz = false;
            inNone = false;

            //changes sprite
            sr.sprite = pumice;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inPum)
        {
            player.tag = "Player";
            inPum = false;

            //changes sprite
            sr.sprite = basic;
            inNone = true;
        }

        //handles switching to and from quartz form
        if (Input.GetKeyDown(KeyCode.Alpha3) && !inQuartz && quartzUnlocked)
        {
            player.tag = "Quartz";
            inQuartz = true;
            inPum = false;
            inGold = false;
            inNone = false;

            //changes sprite
            sr.sprite = quartz;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inQuartz)
        {
            player.tag = "Player";
            inQuartz = false;

            //changes sprite
            sr.sprite = basic;
            inNone = true;
        }

    }
}
