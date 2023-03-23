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
        //handles switching to and from gold form
        if (Input.GetKeyDown(KeyCode.Alpha1) && !inGold)
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
        if(Input.GetKeyDown(KeyCode.Alpha2) && !inPum)
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
        if (Input.GetKeyDown(KeyCode.Alpha3) && !inQuartz)
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
