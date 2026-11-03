using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField] Slider _musicSlider;

    void Start()
    {

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    //public void SoundBalance()
    //{
        //AudioListener.volume = _musicSlider.value;
        //Save();
    //}

    public void soundOn()
    {
        AudioListener.volume = 1;
        Save();
    }

    public void soundOff()
    {
        AudioListener.volume = 0;
        Save();
    }

    private void Load()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
    }
}
