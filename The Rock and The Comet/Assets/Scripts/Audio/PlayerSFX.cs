using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] AudioClip[] crystal;
    [SerializeField] AudioClip[] gold;
    [SerializeField] AudioClip[] pumice;
    [SerializeField] AudioClip[] rock;
    [SerializeField] AudioClip[] damage;

    private AudioSource audioSource;
    private FormSwitching formSwitching;
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        formSwitching = player.GetComponent<FormSwitching>();
        movement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        goldRoll();
    }

    private void goldRoll()
    {
        //if no audio is playing and player is moving horizontal on the ground play gold rolling noise
        if (formSwitching.inGold && !audioSource.isPlaying && movement.movingHorizontal() && movement.checkGrounded())
        {
            audioSource.PlayOneShot(gold[1]);
        }
        else if(!movement.movingHorizontal() || !movement.checkGrounded())
        { 
            audioSource.Stop();
        }
    }
}
