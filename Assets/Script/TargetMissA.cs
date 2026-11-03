using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMissA : MonoBehaviour
{
    public Image PowerBarMaskA;

    public float delta = 1.5f;
    public float speed = 2.0f; 
    private Vector3 startPos;
 
    void Start () 
    {
        startPos = transform.position;
        PowerBarMaskA.fillAmount = 0.5f;
    }
     
    void Update () 
    {
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin (Time.time * speed);
        PowerBarMaskA.fillAmount = v.z;
        transform.position = v;
    }
}
