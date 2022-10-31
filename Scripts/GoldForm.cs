using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldForm : MonoBehaviour
{
    [SerializeField] float minScale = 1f;
    [SerializeField] float normScale = 2f;
    [SerializeField] float changeTimer = 1f;

    [SerializeField]  FormSwitching formSwitch;

    private float currentTimer = 0f;
    private bool isShrunk = false;

    private void FixedUpdate()
    {
        currentTimer -= Time.fixedDeltaTime;
    }

    private void Start()
    {
        //sets player to correct size on start
        gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
    }

    private void Update()
    {
        //let the player manually change size
        if(Input.GetKeyDown(KeyCode.F) && currentTimer <= 0 && formSwitch.inGold)
        {
            if(isShrunk)
            {
                //grow player
                gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);

                isShrunk = false;

                //sets a timer to prevent rapidly changing back and forth, this should help stop weird behavior
                currentTimer = changeTimer;
            } else
            {
                //shrink player
                gameObject.transform.localScale = new Vector3(minScale, minScale, minScale);

                isShrunk = true;

                //sets a timer to prevent rapidly changing back and forth, this should help stop weird behavior
                currentTimer = changeTimer;
            }

            currentTimer = changeTimer;
        } else if(!formSwitch.inGold) gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Gold") && currentTimer <= 0)
        {
            //shrink the player
            if (collision.gameObject.CompareTag("shrink"))
            {
                gameObject.transform.localScale = new Vector3(minScale, minScale, minScale);

                //sets a timer to prevent rapidly changing back and forth, this should help stop weird behavior
                currentTimer = changeTimer;
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
            if (collision.gameObject.CompareTag("grow") && currentTimer <= 0)
            {
                gameObject.transform.localScale = new Vector3(normScale, normScale, normScale);
            }
            Debug.Log("gold not active");
        }
    }
    */
}
