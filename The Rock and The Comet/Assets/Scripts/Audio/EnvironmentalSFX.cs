using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentalSFX : MonoBehaviour
{
    [SerializeField] float soundTickSpeed = 5;
    [SerializeField] bool isEnabled = false;

    private AudioManager audioManager;

    private float waterDripTimer = 0;
    private float caveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isEnabled)
        {
            audioManager = GetComponent<AudioManager>();

            InvokeRepeating("tickCounters", 0, 1);
            InvokeRepeating("tickSounds", 0, soundTickSpeed);
        }
    }

    //attempts to randomly play some sounds
    void tickSounds()
    {
        //gets random numbers to cue up ambient noises
        int randInt = Random.Range(0, 100);


        //should try to not have value ranges overlap
        caveAmbient(randInt, 1, 10);
        waterDripAmbient(randInt, 90, 100);
    }



    //counts each timer down by 1 every second to ensure audio doesn't play overlapping the same sounds
    private void tickCounters()
    {
        //checking if > -1 so that way the values can be safely less than zero and ensures no overlap

        if (waterDripTimer > -1)
            waterDripTimer--;

        if (caveTimer > -1)
            caveTimer--;
    }

    //if player is close to lava play lava ambience
    private void lavaAmbient()
    {
        audioManager.playSound("Lava Ambience");
    }

    //play cave ambience if i is inside a valid range
    private void caveAmbient(int i, int low, int high)
    {
        if (caveTimer < 0 && i < high && i > low)
        {
            audioManager.playSound("Cave Ambience");
            caveTimer = audioManager.getDuration("Cave Ambience");
        }
    }

    //play water dripping ambience if i is inside a valid range
    private void waterDripAmbient(int i, int low, int high)
    {
        if (waterDripTimer < 0 && i < high && i > low)
        {
            audioManager.playSound("Water Drip");
            waterDripTimer = audioManager.getDuration("Water Drip");
        }
    }
}
