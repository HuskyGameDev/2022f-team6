using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedPlayerHealth : MonoBehaviour
{

    //for respawn functionality 
    private Transform spawnPoint;
    private Transform playerPos;
    public static int entryPointNum = 0;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject transition;
    [SerializeField] GameObject transCanvas;
    public Map map;
    public LevelSwitcher switcher;
    public AudioSource bgm;

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
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos.position = findSpawnPoint(entryPointNum).position;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        spawnPoint.position = findSpawnPoint(entryPointNum).position;
        Debug.Log(playerPos);
        currentHp = maxHp;

        animator.SetBool("No Damage", true);
        animator.SetBool("1 Damage", false);
        animator.SetBool("2 Damage", false);
        StartCoroutine(Fade(false, transition.GetComponent<Image>(), null));
        bgm.Play();
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
        else if (collision.gameObject.CompareTag("Switch"))
        {
            StartCoroutine(Fade(true, transition.GetComponent<Image>(), collision));
            StartCoroutine(fadeMusic(true, bgm));
            setSpawnPoint(collision);
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

    IEnumerator Fade(bool fadeIn, Image img, Collider2D collision)
    {
        if (!fadeIn)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(.046f, .0456f, .0566f, i);
                yield return null;
            }
            img.color = new Color(.046f, .0456f, .0566f, 0);
            transCanvas.SetActive(false);
            yield return null;
        }
        else if (fadeIn)
        {
            transCanvas.SetActive(true);
            for (float i = 0; i <=1; i += Time.deltaTime)
            {
                img.color = new Color(.046f, .0456f, .0566f, i);
                yield return null;
            }
            img.color = new Color(.046f, .0456f, .0566f, 1);
            yield return null;
        }
        if(collision != null)
        {
            yield return new WaitForSeconds(1);
            setSpawnPoint(collision);
        }
        
    }

    public void setSpawnPoint(Collider2D collision)
    {
        string name = collision.gameObject.name;
        switch (name)
        {
            case "Entrance0":
                entryPointNum = 1;
                switcher.caves2();
                break;
            case "Entrance1":
                entryPointNum = 4;
                switcher.caves1();
                break;
            case "Entrance2":
                entryPointNum = 3;
                switcher.caves1();
                break;
            case "Entrance3":
                entryPointNum = 5;
                switcher.crystalCaves();
                break;
            case "Entrance4":
                entryPointNum = 6;
                switcher.crystalCaves();
                break;
            case "Entrance5":
                entryPointNum = 2;
                switcher.caves2();
                break;
            case "Entrance6":
                entryPointNum = 7;
                switcher.caves1();
                break;
            case "Entrance7":
                entryPointNum = 8;
                switcher.caves1();
                break;
            case "Entrance8":
                entryPointNum = 9;
                switcher.surfaceLevel();
                break;
            case "Entrance9":
                entryPointNum = 10;
                switcher.surfaceLevel();
                break;
            case "Entrance10":
                entryPointNum = 13;
                switcher.volcano();
                break;
            case "Entrance11":
                entryPointNum = 11;
                switcher.volcano();
                break;
            case "Entrance12":
                entryPointNum = 12;
                switcher.volcano();
                break;
            case "Entrance13":
                entryPointNum = 16;
                switcher.crystalCaves();
                break;
            case "Entrance14":
                entryPointNum = 14;
                switcher.surfaceLevel();
                break;
            case "Entrance15":
                entryPointNum = 15;
                switcher.caves1();
                break;
            case "Exit To Credits":
                switcher.credits();
                break;
        }
    }

    public Transform findSpawnPoint(int i)
    {
        switch (i)
        {
            case (0):
                return GameObject.Find("Spawn0").transform;               
            case (1):
                return GameObject.Find("Spawn1").transform;                
            case (2):
                return GameObject.Find("Spawn2").transform;                
            case (3):
                return GameObject.Find("Spawn3").transform;                
            case (4):
                return GameObject.Find("Spawn4").transform;                
            case (5):
                return GameObject.Find("Spawn5").transform;                
            case (6):
                return GameObject.Find("Spawn6").transform;                
            case (7):
                return GameObject.Find("Spawn7").transform;                
            case (8):
                return GameObject.Find("Spawn8").transform;
            case (9):
                return GameObject.Find("Spawn9").transform;
            case (10):
                return GameObject.Find("Spawn10").transform;
            case (11):
                return GameObject.Find("Spawn11").transform;
            case (12):
                return GameObject.Find("Spawn12").transform;
            case (13):
                return GameObject.Find("Spawn13").transform;
            case (14):
                return GameObject.Find("Spawn14").transform;
            case (15):
                return GameObject.Find("Spawn15").transform;
            case (16):
                return GameObject.Find("Spawn16").transform;
                
        }
        return null;
    }

    IEnumerator fadeMusic(bool fadeIn, AudioSource audio)
    {
        if (fadeIn)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                audio.volume = Mathf.Lerp(audio.volume, 0, i);
                yield return null;
            }
        }
        else if (!fadeIn)
        {
            for (float i = 1; i >= 0; i-= Time.deltaTime)
            {
                audio.volume = Mathf.Lerp(audio.volume, 1, i);
                yield return null;
            }
        }
        
    }
}
