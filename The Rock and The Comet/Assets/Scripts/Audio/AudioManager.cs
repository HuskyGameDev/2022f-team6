using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private Sound[] sounds;
    [SerializeField] Sound[] ambientSounds;
    [SerializeField] Sound[] playerSounds;
    [SerializeField] Sound[] music;

    AudioSource musicSource;

    private void Start()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();

        combineArrays();

        //setup all the sounds
        foreach (Sound s in sounds)
        {
            //create and assign audio sources to all the sounds
            if (s.type == Sound.SoundType.sfx)
            {
                s.source  = this.gameObject.AddComponent<AudioSource>();
            } else if (s.type == Sound.SoundType.music)
            {
                s.source = musicSource;
            }

            //configure the audio source
            try
            {
                s.source.clip = s.clip;
            } catch (NullReferenceException)
            {
                Debug.LogWarning("No audio clip was provided for sound " + s.name);
            }

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    //this probably isn't effecient but its easy, might optimize it later
    private void combineArrays()
    {
        sounds = new Sound[ambientSounds.Length + playerSounds.Length + music.Length];

        int i = 0;

        foreach(Sound s in ambientSounds)
        {
            sounds[i] = ambientSounds[i++];
        }

        int j = 0;

        foreach (Sound s in playerSounds)
        {
            sounds[i+j] = playerSounds[j++];
        }

        int k = 0;

        foreach (Sound s in music)
        {
            sounds[i+j+k] = music[k++];
        }
    }

    //stops music
    private void ifNameNone(String soundName)
    {
        if(soundName.Equals("none"))
        {
            musicSource.Stop();
        }
    }

    //plays a sound based of its name
    public void playSound(String audioName)
    {
        ifNameNone(audioName);

        Sound sound = null;
        sound = Array.Find(sounds, sound => sound.name == audioName);

        if (sound != null)
        {
            //prevent overlapping music
            if (sound.type == Sound.SoundType.music)
            {
                sound.source.Stop();
                sound.source.volume = sound.volume;
                sound.source.loop = sound.loop;
                sound.source.clip = sound.clip;
                sound.source.Play();
            } else
            {
                if(!sound.source.isPlaying)
                    sound.source.Play();
            }
        }
        else Debug.LogWarning("Unable to play sound " + audioName + " as it was not found in the given sound files, please check for correct spelling");
    }

    //stop a specifc sound from playing based on its name
    public void stopSound(String audioName)
    {
        ifNameNone(audioName);

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

    //returns an array of all the music sounds
    public List<String> getMusicTracks()
    {
        List<String> music = new List<string>();
        music.Add("none");

        foreach(Sound s in sounds)
        {
            if (s.type == Sound.SoundType.music)
                music.Add(s.name);
        }

        return music;
    }

    //updates all music volume
    public void updateMusicVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Sound.SoundType.music)
                s.volume = volume;
        }

        musicSource.volume = volume;
    }

    //returns the duration of the song
    public float getDuration(String soundName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);

        return sound.clip.length;
    }
}
