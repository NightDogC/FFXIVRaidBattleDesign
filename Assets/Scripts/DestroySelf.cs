using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float lastingTime;
    void Awake()
    {
        StartCoroutine("Des",lastingTime);
    }

    IEnumerator Des(float lastingTime)
    {
        yield return new WaitForSeconds(lastingTime);
        Destroy(this.gameObject);
    }
}
