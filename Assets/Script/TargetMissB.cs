using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMissB : MonoBehaviour
{
    public Image PowerBarMaskB;

    public float delta = 1.5f;
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        PowerBarMaskB.fillAmount = 0.5f;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        PowerBarMaskB.fillAmount = v.z;
        transform.position = v;
    }
}
