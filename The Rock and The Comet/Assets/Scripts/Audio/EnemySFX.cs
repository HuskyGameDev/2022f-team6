using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    [SerializeField] float soundTickSpeed = 5;

    private GameObject[] enemies;
    private AudioManager am;

    private float scuttleTimer = 0;
    private float waterTimer = 0;
    private float bigDragonTimer = 0;
    private float babyDragonTimer = 0;
    private float beetleTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<AudioManager>();

        getEnemies();

        InvokeRepeating("tickCounters", 0, 1);
        InvokeRepeating("tickSounds", 0, soundTickSpeed);
    }

    //attempts to randomly play some sounds
    void tickSounds()
    {
        foreach (GameObject g in enemies)
        {
            if (g != null)
            {
                AudioSource audioSource = g.GetComponent<AudioSource>();

                int randInt = Random.Range(0, 10);

                switch (determineEnemy(g))
                {
                    case "scuttle plant":
                        scuttleSFX(randInt, audioSource);
                        break;
                    case "water slime":
                        waterSFX(randInt, audioSource);
                        break;
                    case "big dragon":
                        bigDragonSFX(randInt, audioSource);
                        break;
                    case "baby dragon":
                        babyDragonSFX(randInt, audioSource);
                        break;
                    case "lava beetle":
                        lavaBeetleSFX(randInt, audioSource);
                        break;
                    case "unkown":
                        break;
                }
            }
        }
    }

    //stores all the enemies in the scene to play sfx on and adds an audio player to them
    private void getEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject g in enemies)
        {
            AudioSource audioSource = g.AddComponent<AudioSource>();
        }
    }

    //counts each timer down by 1 every second to ensure audio doesn't play overlapping the same sounds
    private void tickCounters()
    {
        //checking if > -1 so that way the values can be safely less than zero and ensures no overlap

        if (scuttleTimer > -1)
            scuttleTimer--;

        if (waterTimer > -1)
            waterTimer--;

        if (bigDragonTimer > -1)
            bigDragonTimer--;

        if (babyDragonTimer > -1)
            babyDragonTimer--;

        if (beetleTimer > -1)
            beetleTimer--;
    }

    //figures out which sounds need to be played
    private string determineEnemy(GameObject enemy)
    {
        string spriteName = enemy.GetComponent<SpriteRenderer>().sprite.name;

        switch(spriteName)
        {
            case "SurfaceEnemy":
                return "scuttle plant";
            case "CrystalEnemy":
                return "water slime";
            case "DragonBoss":
                return "big dragon";
            case "VolcanoEnemy":
                return "baby dragon";
            case "VolcanoEnemy2":
                return "lava beetle";
            case "CaveEnemy":
                //just gonna treat the worm like a plant for sounds
                return "scuttle plant";
        }

        return "unkown";
    }
    
    private void scuttleSFX(int random, AudioSource source)
    {
        if (scuttleTimer < 0 && random < 5 && random > 0)
        {
            am.playSoundOn("Scuttle-1", source);
            scuttleTimer = am.getDuration("Scuttle-1");
        }
        else if (scuttleTimer < 0 && random < 10 && random > 5)
        {
            am.playSoundOn("Scuttle-2", source);
            scuttleTimer = am.getDuration("Scuttle-2");
        }
    }

    private void waterSFX(int random, AudioSource source)
    {
        if (waterTimer < 0 && random < 2 && random > 0)
        {
            am.playSound("Water Bloop-1");
            waterTimer = am.getDuration("Water Bloop-1");
        }
        else if (waterTimer < 0 && random < 4 && random > 2)
        {
            am.playSound("Water Bloop-2");
            waterTimer = am.getDuration("Water Bloop-2");
        }
        else if (waterTimer < 0 && random < 6 && random > 4)
        {
            am.playSound("Water Bloop-3");
            waterTimer = am.getDuration("Water Bloop-3");
        }
        else if (waterTimer < 0 && random < 10 && random > 6)
        {
            am.playSound("Water Bloop-4");
            waterTimer = am.getDuration("Water Bloop-4");
        }
    }

    private void bigDragonSFX(int random, AudioSource source)
    {
        if (bigDragonTimer < 0 && random < 5 && random > 0)
        {
            am.playSound("Big Dragon-1");
            bigDragonTimer = am.getDuration("Big Dragon-1");
        }
        else if (bigDragonTimer < 0 && random < 10 && random > 5)
        {
            am.playSound("Big Dragon-2");
            bigDragonTimer = am.getDuration("Big Dragon-2");
        }
    }

    private void babyDragonSFX(int random, AudioSource source)
    {
        if (babyDragonTimer < 0 && random < 5 && random > 0)
        {
            am.playSound("Small Dragon-1");
            babyDragonTimer = am.getDuration("Small Dragon-1");
        }
        else if (babyDragonTimer < 0 && random < 10 && random > 5)
        {
            am.playSound("Small Dragon-2");
            babyDragonTimer = am.getDuration("Small Dragon-2");
        }
    }

    private void lavaBeetleSFX(int random, AudioSource source)
    {
        if (beetleTimer < 0 && random < 5 && random > 0)
        {
            am.playSound("Lava Beetle-1");
            beetleTimer = am.getDuration("Lava Beetle-1");
        }
        else if (beetleTimer < 0 && random < 10 && random > 5)
        {
            am.playSound("Lava Beetle - 2");
            beetleTimer = am.getDuration("Lava Beetle-2");
        }
    }
}
