using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmove : MonoBehaviour
{
    public Rigidbody rbA;
    public float MoveSpeedA = 5;
    public float JumpHightA = 8;
    public bool ObjectGroundedA = true;

    void Update()
    {
        //walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal_1"), 0, Input.GetAxisRaw("Vertical_1"));
        transform.position += direction * MoveSpeedA * Time.deltaTime;
        transform.LookAt(transform.position + direction);

        //jump
        if (Input.GetKeyDown(KeyCode.E) && ObjectGroundedA == true)
        {
            rbA.linearVelocity = Vector3.up * JumpHightA;
            ObjectGroundedA = false;
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rbA.linearVelocity = Vector3.down * JumpHightA;
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ObjectGroundedA = true;
        }
    }
}
