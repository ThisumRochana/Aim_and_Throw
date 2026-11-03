using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    AudioManager GameAudio;

    //Game Over Panel
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameoverScoreA;
    public TextMeshProUGUI gameoverScoreB;
    public TextMeshProUGUI winPlayer;

    //score system veriabel
    public int ScoreA;
    public int ScoreB;
    public int plus = 1;
    public float Timer = 120f;

    //HUD Text veriabel
    public TextMeshProUGUI scoreAtext;
    public TextMeshProUGUI  scoreBtext;
    public TextMeshProUGUI TimerText;

    public bool GameEnD =  false;

    public AudioClip GameOver;

    private void Awake()
    {
        GameAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Start()
    {
        if (!GameEnD)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }

        //ball randem position
        GetComponent<MeshRenderer>().enabled = true;
        gameObject.transform.position = new Vector3(0, 0.283f, Random.Range(7, -7));

        GameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider score)
    {
        if (score.gameObject.tag == "ColliderA")
        {
            GameAudio.PlaySFX(GameAudio.point);
            ScoreA += plus;
            scoreAtext.text = ScoreA.ToString("00");
        }
        else if (score.gameObject.tag == "ColliderB")
        {
            GameAudio.PlaySFX(GameAudio.point);
            ScoreB += plus;
            scoreBtext.text = ScoreB.ToString("00");
        }
    }

    public Ball ball;
    private void Update()
    {
        Timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60);
        int seconds = Mathf.FloorToInt(Timer % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (Timer <= 0)
        {
            //GameAudio.audioSource.Stop();
            GameEnD = true;
            Time.timeScale = 0;
            Timer = 0;
            GameOverPanel.SetActive(true);
            gameoverScoreA.text = scoreAtext.text;
            gameoverScoreB.text = scoreBtext.text;

            if (ScoreA > ScoreB)
            {
                winPlayer.GetTextInfo("Win Super Kings");
            }
            else if (ScoreA < ScoreB)
            {
                winPlayer.GetTextInfo("Win Team Wolfs");
            }
            else
            {
                winPlayer.GetTextInfo("Match Draw");
            }

        }
    }


}//class