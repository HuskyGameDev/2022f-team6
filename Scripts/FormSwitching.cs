using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormSwitching : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool inGold = false;
    public bool inPum = false;
    /**KEY
     1 = GoldForm
    2 = Pummice form*/

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

    // Update is called once per frame
    void Update()
    {
        //if the 1 key is pressed the players tag is set to gold
        if (Input.GetKeyDown(KeyCode.Alpha1) && !inGold)
        {
            player.tag = "Gold";
            inGold = true;
            inPum = false;

            //changes sprite
            sr.sprite = gold;
        }
        //if the 1 key is pressed while the player is in gold form the tag becomes player
        else if (Input.GetKeyDown(KeyCode.Alpha1) && inGold)
        {
            player.tag = "Player";
            inGold = false;

            //changes sprite
            sr.sprite = basic;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && !inPum)
        {
            player.tag = "Pumice";
            inPum = true;
            inGold = false;

            //changes sprite
            sr.sprite = pumice;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && inPum)
        {
            player.tag = "Player";
            inPum = false;

            //changes sprite
            sr.sprite = basic;
        }
   
    }
}
