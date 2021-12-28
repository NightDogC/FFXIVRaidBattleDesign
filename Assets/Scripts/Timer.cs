using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float phaseTime;
    void Start()
    {
        phaseTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        phaseTime += Time.deltaTime;
    }
}
