using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBmove : MonoBehaviour
{
    public Rigidbody rbB;
    public float MoveSpeedB = 5;
    public float JumpHightB = 8;
    public bool ObjectGroundedB = true;


    void Update()
    {
        //walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * MoveSpeedB * Time.deltaTime;
        transform.LookAt(transform.position + direction);

        //jump
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && ObjectGroundedB == true)
        {
            rbB.linearVelocity = Vector3.up * JumpHightB;
            ObjectGroundedB = false;
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            rbB.linearVelocity = Vector3.down * JumpHightB;
            GetComponent<Rigidbody>().freezeRotation = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ObjectGroundedB = true;
        }
    }
}