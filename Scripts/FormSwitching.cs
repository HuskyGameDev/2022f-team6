using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FormSwitching : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool inGold = false;
    bool inPum = false;
   /**KEY
    1 = GoldForm
   2 = Pummice form*/



    // Update is called once per frame
    void Update()
    {
        //if the 1 key is pressed the players tag is set to gold
        if (Input.GetKeyDown(KeyCode.Alpha1) && !inGold)
        {
            player.tag = "Gold";
            inGold = true;
            Debug.Log("Gold = " + inGold);
        }
        //if the 1 key is pressed while the player is in gold form the tag becomes player
        else if (Input.GetKeyDown(KeyCode.Alpha1) && inGold)
        {
            player.tag = "Player";
            inGold = false;
            Debug.Log("Gold = " + inGold);

        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && !inPum)
        {
            player.tag = "Pumice";
            inPum = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && inPum)
        {
            player.tag = "Player";
            inPum = false;
        }
   
    }
}
