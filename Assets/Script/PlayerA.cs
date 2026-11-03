using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
{
    public Transform Ball;
    public Transform ArmA_R;
    public Transform ArmA_L;
    public Transform PosOverHeadA;
    public Transform PosDribbeleA;
    public Transform TargetA;
    public Transform DropA;
    public Transform TargetLook_A;

    public Transform RandomDropA;

    //variables
    public bool IsBallInHandsA = false;
    private bool IsBallFlying = false;
    private float T = 0;
    public bool ColiderOnA;


    public void Update()
    {
        //ball in hand
        if (IsBallInHandsA)
        {
            //hold over head 
            if (Input.GetKey(KeyCode.Space))
            {
                Ball.position = PosOverHeadA.position;
                ArmA_R.localEulerAngles = Vector3.right * -270;
                ArmA_L.localEulerAngles = Vector3.right * -270;
                Ball.GetComponent<Rigidbody>().freezeRotation = true;

                //look towards the target
                transform.LookAt(TargetLook_A);
            }

            else         
            {
                Ball.position = PosDribbeleA.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                ArmA_R.localEulerAngles = Vector3.right * -180;
                ArmA_L.localEulerAngles = Vector3.right * -90;
                GetComponent<BoxCollider>().enabled = true;
                ColiderOnA = true;
            }

            //throw ball 
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsBallInHandsA = false;
                IsBallFlying = true;
                T = 0;
                Ball.GetComponent<Rigidbody>().freezeRotation = false;
            }

        }
        else
        {
            ArmA_R.localEulerAngles = Vector3.right * -90;
            GetComponent<BoxCollider>().enabled = false;
            ColiderOnA = false;
        }


        //ball in air
        if (IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = PosOverHeadA.position;
            Vector3 B = TargetA.position;
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
                Ball.position = DropA.position;
            }
        }
    }

    private void OnTriggerEnter(Collider otherA)
    {
        if (!IsBallInHandsA && !IsBallFlying)
        {

            IsBallInHandsA = true;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
            Ball.GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
