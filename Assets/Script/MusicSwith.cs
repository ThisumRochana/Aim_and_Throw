using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicSwith : MonoBehaviour
{
    //public GameObject AudioGame;

    AudioManager audioManager;

    public Slider _musicSwith;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void MusicOnOff()
    {
        if (_musicSwith.value == 0)
        {
            audioManager.audioSource.Stop();
        }
        else
        {
            audioManager.audioSource.Play();
        }
    }
}
