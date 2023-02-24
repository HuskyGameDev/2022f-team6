using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] musicTracks;

    private AudioSource source;
    private int currentTrack = 0;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //just to test some methods, eventually this should be handled by a ui or something
        if(Input.GetKeyDown(KeyCode.P))
        {
            playNewTrack(0);
        }
    }

    //switches the music to a specific track
    public void playNewTrack(int track)
    {
        currentTrack = track;
        source.Stop();
        source.PlayOneShot(musicTracks[track]);
    }

    //an overload that plays the next track in order given by the musicTracks array
    public void playNewTrack()
    {
        source.Stop();

        if (currentTrack < musicTracks.Length)
        {
            source.PlayOneShot(musicTracks[currentTrack++]);
        } else
        {
            source.PlayOneShot(musicTracks[0]);
            currentTrack = 0;
        }
    }

    //control if music continues to loop or not
    public void setLoop(bool loopTracks)
    {
        source.loop = loopTracks;
    }

    //control the volume music plays at, pass a value between 0 and 100 with 100 being the loudest the audio can be
    public void setVolume(float volume)
    {
        source.volume = (volume/100f);
    }

    //resets the audio values back to a default state
    public void resetValues()
    {
        //start playing the first track
        currentTrack = 0;
        source.PlayOneShot(musicTracks[currentTrack]);

        setLoop(true);

        setVolume(100);
    }
}
