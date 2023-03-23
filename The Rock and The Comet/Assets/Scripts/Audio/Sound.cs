using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//this is a helper class to the AudioManager script, this provides some info that will be used there to load audio clips easier

[System.Serializable]
public class Sound
{
    [Tooltip("a unique name to find find the audio from")]
    public string name = null;

    //specify the type to determine which audio player is used for this sound (music gets 1 player, sfx gets 1 per sound
    public enum SoundType { sfx, music };
    [Tooltip("Determines audio player")]
    public SoundType type;

    [Tooltip("The audio file you desire to play")]
    public AudioClip clip = null;

    [Tooltip("The default volume the audio will play at")]
    [Range(0f,1f)]
    public float volume = 1;

    //note: this doesn't dictate if it will play or not, only that it will loop if play conditions are continually met
    [Tooltip("If the sound should be set to loop")]
    public bool loop = false;

    [HideInInspector]
    //save the audio source being used to play this audio
    public AudioSource source = null;
}
