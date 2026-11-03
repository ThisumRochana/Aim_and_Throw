using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public float speed = 0.5f;
    public Transform Ball;
    public Transform ArmB_R;
    public Transform ArmB_L;
    public Transform PosOverHeadB;
    public Transform PosDribbeleB;
    public Transform TargetB;
    public Transform DropB;
    public Transform TargetLookB;

    public Transform RandomDropB;

    //variables
    public bool IsBallInHandsB = false;
    private bool IsBallFlying = false;
    private float T = 0;
    public bool ColiderOnB;


    public void Update()
    {
        //ball in hand
        if (IsBallInHandsB)
        {
            //hold over head 
            if (Input.GetKey(KeyCode.Keypad0))
            {
                Ball.position = PosOverHeadB.position;
                ArmB_R.localEulerAngles = Vector3.right * -270;
                ArmB_L.localEulerAngles = Vector3.right * -270;
                Ball.GetComponent<Rigidbody>().freezeRotation = true;

                //look towards the target
                transform.LookAt(TargetLookB);
            }

            else
            {
                Ball.position = PosDribbeleB.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                ArmB_R.localEulerAngles = Vector3.right * -180;
                ArmB_L.localEulerAngles = Vector3.right * -90;
                GetComponent<BoxCollider>().enabled = true;
                ColiderOnB = true;
            }

            //throw ball 
            if (Input.GetKeyUp(KeyCode.Keypad0))
            {
                IsBallInHandsB = false;
                IsBallFlying = true;
                T = 0;
                Ball.GetComponent<Rigidbody>().freezeRotation = false;

            }

        }
        else
        {
            ArmB_R.localEulerAngles = Vector3.right * -90;
            GetComponent<BoxCollider>().enabled = false;
            ColiderOnB = false;

        }


        //ball in air
        if (IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = PosOverHeadB.position;
            Vector3 B = TargetB.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            //move in arc
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            Ball.position = pos + arc;

            //when moment ball arives at the target
            if (t01 >= 1)
            {
                IsBallFlying = false;
                Ball.GetComponent<Rigidbody>().isKinematic = false;
                Ball.GetComponent<Rigidbody>().useGravity = false;
                Ball.position = DropB.position;

            }
        }
    }

    private void OnTriggerEnter(Collider otherB)
    {
        if (!IsBallInHandsB && !IsBallFlying)
        {

            IsBallInHandsB = true;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
            Ball.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
