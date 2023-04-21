using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] GameObject player;

    private AudioManager audioManager;
    private FormSwitching formSwitching;
    private Movement movement;

    private bool goldRolling = false;
    private bool stoneRolling = false;
    private bool quartzRolling = false;
    private bool pumiceRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        formSwitching = player.GetComponent<FormSwitching>();
        movement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement.movingHorizontal())
            stopRolls();


        goldRoll();
        stoneRoll();
        quartzRoll();
        //pumiceRoll(); uncomment this when there is a pumice roll sound added
    }

    //is played when the player collides with something
    public void fallHit()
    {
        if (formSwitching.inNone)
        {
            audioManager.playSound("Stone Landing");
        }
        else if (formSwitching.inGold)
        {
            audioManager.playSound("Gold Landing");
        }
        else if (formSwitching.inQuartz)
        {
            audioManager.playSound("Quartz Landing");
        }
        else if (formSwitching.inPum)
        {
            audioManager.playSound("Stone Landing"); 
        }
    }

    //while player is falling
    private void falling()
    {
        audioManager.playSound("Falling");
    }

    //if player touches lava
    public void lavaHit()
    {
        audioManager.playSound("Lava Hit");
    }

    private void stopRolls()
    {
        audioManager.stopSound("Gold Rolling");
        audioManager.stopSound("Stone Rolling");
        audioManager.stopSound("Quartz Rolling");
    }

    private void goldRoll()
    {
        //if no audio is playing and player is moving horizontal on the ground play gold rolling noise
        if (!goldRolling && formSwitching.inGold && movement.movingHorizontal() && movement.checkGrounded())
        {
            stopRolls();
            audioManager.playSound("Gold Rolling");
            goldRolling = true;
        }
        else if(!movement.movingHorizontal() || !movement.checkGrounded())
        {
            audioManager.stopSound("Gold Rolling");
            goldRolling = false;
        }
    }

    private void stoneRoll()
    {
        //if no audio is playing and player is moving horizontal on the ground play gold rolling noise
        if (!stoneRolling && formSwitching.inNone && movement.movingHorizontal() && movement.checkGrounded())
        {
            stopRolls();
            audioManager.playSound("Stone Rolling");
            stoneRolling = true;
        }
        else if (!movement.movingHorizontal() || !movement.checkGrounded())
        {
            audioManager.stopSound("Stone Rolling");
            stoneRolling = false;
        }
    }

    private void quartzRoll()
    {
        //if no audio is playing and player is moving horizontal on the ground play gold rolling noise
        if (!quartzRolling && formSwitching.inQuartz && movement.movingHorizontal() && movement.checkGrounded())
        {
            stopRolls();
            audioManager.playSound("Quartz Rolling");
            quartzRolling = true;
        }
        else if (!movement.movingHorizontal() || !movement.checkGrounded())
        {
            audioManager.stopSound("Quartz Rolling");
            quartzRolling = false;
        }
    }

    private void pumiceRoll()
    {
        //if no audio is playing and player is moving horizontal on the ground play gold rolling noise
        if (!pumiceRolling && formSwitching.inPum && movement.movingHorizontal() && movement.checkGrounded())
        {
            stopRolls();
            audioManager.playSound("Stone Rolling");
            quartzRolling = true;
        }
        else if (!movement.movingHorizontal() || !movement.checkGrounded())
        {
            audioManager.stopSound("Stone Rolling");
            quartzRolling = false;
        }
    }
}
