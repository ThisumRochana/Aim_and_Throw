using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faultscript : MonoBehaviour
{
    public PlayerA playerA;
    public PlayerB playerB;
    Ball ball;

    public GameObject FaultPanel;

    public bool Gamehavefault = false;
    public bool Faultbuttonpress = false;


    public void Update()
    {
        if ((playerA.ColiderOnA == true)&& playerB.ColiderOnB == true)
        {

            Gamehavefault = true;
            playerA.RandomDropA.position = new Vector3(Random.Range(-12, 12), 0, Random.Range(7, -7));
            playerB.RandomDropB.position = new Vector3(Random.Range(-12, 12), 0, Random.Range(7, -7));
            Time.timeScale = 0;
            FaultPanel.SetActive(true);
        }

    }

    public void FaultButton()
    {
        Gamehavefault = false;
        playerA.IsBallInHandsA = false;
        playerB.IsBallInHandsB = false;
        playerA.transform.position = playerA.DropA.position;
        playerB.transform.position = playerB.DropB.position;
        Faultbuttonpress = true;
    }

    public void playnow()
    {
        if (Faultbuttonpress == true)
        {
            Gamehavefault = false;
            playerA.IsBallInHandsA = false;
            playerB.IsBallInHandsB = false;
            playerA.transform.position = playerA.RandomDropA.position;
            playerB.transform.position = playerB.RandomDropB.position;
            FaultPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
