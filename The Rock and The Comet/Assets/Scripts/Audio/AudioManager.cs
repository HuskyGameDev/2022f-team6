using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;

    private void Start()
    {
        AudioSource musicSource = this.gameObject.AddComponent<AudioSource>();

        //setup all the sounds
        foreach (Sound s in sounds)
        {
            //create and assign audio sources to all the sounds
            if (s.type.Equals("sfx"))
            {
                s.source  = this.gameObject.AddComponent<AudioSource>();
            } else if (s.type.Equals("music"))
            {
                s.source = musicSource;
            }

            //configure the audio source
            try
            {
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.loop = s.loop;
            } catch (NullReferenceException e)
            {
                Debug.LogWarning("No audio clip was provided for sound " + s.name);
            }
        }
    }

    //plays a sound based of its name
    public void playSound(String audioName)
    {
        Sound sound = null;
        sound = Array.Find(sounds, sound => sound.name == audioName);

        if (sound != null)
        {
            //prevent overlapping music
            if (sound.type.Equals("music"))
            {
                sound.source.Stop();
                sound.source.PlayOneShot(sound.clip);
            }
            else sound.source.Play();
        }
        else Debug.LogWarning("Unable to play sound " + audioName + " as it was not found in the given sound files, please check for correct spelling");
    }

    //stop a specifc sound from playing based on its name
    public void stopSound(String audioName)
    {
        Sound sound = null;
        sound = Array.Find(sounds, sound => sound.name == audioName);

        if (sound != null)
        {
            sound.source.Stop();
        }
        else Debug.LogWarning("Unable to stop sound " + audioName + " as it was not found in the given sound files, please check for correct spelling");
    }

    //makes all audio stop (I'm assuming this would only really be used if we do a cutscene)
    public void stopAllSounds()
    {
        foreach(Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
