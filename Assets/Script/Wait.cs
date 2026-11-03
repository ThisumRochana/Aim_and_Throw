using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{

    public float WaitTime = 6f;
    void Start()
    {
        StartCoroutine(Waitintro());
    }

    IEnumerator Waitintro()
    {
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadSceneAsync(1);
    }
}
