using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source----------")]
    public  AudioSource audioSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Clip----------")]
    public AudioClip background;
    public AudioClip Gamebackground;
    public AudioClip buttonclick;
    public AudioClip point;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
