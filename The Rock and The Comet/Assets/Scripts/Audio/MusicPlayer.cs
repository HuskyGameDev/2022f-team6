using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameObject musicMenu;
    [SerializeField] GameObject volumeSlider;

    private AudioManager audioManager;
    private Dropdown songDropdown;

    private void Start()
    {
        audioManager = this.gameObject.GetComponent<AudioManager>();
        songDropdown = musicMenu.GetComponentInChildren<Dropdown>();

        populateDropdown();

        //calls the DropdownValueChanged when the value changes
        songDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(songDropdown);
        });
    }

    //repopulates the dropdown list eachtime the game is loaded (makes sure if songs were added/removed this is updated)
    private void populateDropdown()
    {
        songDropdown.ClearOptions();
        songDropdown.AddOptions(audioManager.getMusicTracks());
    }

    //play a song based on dropdowns value
    void DropdownValueChanged(Dropdown change)
    {
        audioManager.playSound(songDropdown.options[songDropdown.value].text);
    }

    public void changeMusicVolume()
    {
        audioManager.updateMusicVolume(volumeSlider.GetComponent<Slider>().value);
    }
}
