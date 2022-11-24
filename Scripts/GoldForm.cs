using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldForm : MonoBehaviour
{
    //set these in the unity editor
    [SerializeField] float minScale = 1f;
    [SerializeField] float normScale = 2f;
    [SerializeField] float changeTimer = 1f;

    //grab this from an object in the editor mode
    [SerializeField]  FormSwitching formSwitch;

    //some variables used to keep track of things
    private float currentTimer = 0f;
    private bool isShrunk = false;

    private void FixedUpdate()
    {
        //ticks the timer down at a constant rate
        currentTimer -= Time.fixedDeltaTime;
    }

    private void Start()
    {
        //sets player to correct size on start
        gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
    }

    private void Update()
    {
        //let the player manually change size (auto switches to normal size when exiting gold form)
        if(Input.GetKeyDown(KeyCode.F) && currentTimer <= 0 && formSwitch.inGold)
        {
            if(isShrunk)
            {
                //grow player
                gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);

                isShrunk = false;
            } else
            {
                //shrink player
                gameObject.transform.localScale = new Vector3(minScale, minScale, minScale);

                isShrunk = true;
            }

            //sets a timer to prevent rapidly changing back and forth, this should help stop weird behavior
            currentTimer = changeTimer;
        } else if(!formSwitch.inGold) gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
    }
}
