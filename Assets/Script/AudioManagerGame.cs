using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    [Header("---------- Audio Source----------")]
    public AudioSource muscicSource;
    [SerializeField] AudioSource GameSFXSource;


    [Header("---------- Audio Clip----------")]
    public AudioClip Gamebackground;
    public AudioClip Crowd;
    public AudioClip point;
    public AudioClip buttonclick;

    public void Start()
    {
        muscicSource.clip = Gamebackground;
        muscicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        GameSFXSource.PlayOneShot(clip);
    }
}
