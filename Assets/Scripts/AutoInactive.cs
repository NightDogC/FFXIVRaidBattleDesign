using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoInactive : MonoBehaviour
{
    public int lastingTime;
    private void OnEnable()
    {
        lastingTime = 2;
        Invoke("SetActiveFalse",lastingTime);
    }
    void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
