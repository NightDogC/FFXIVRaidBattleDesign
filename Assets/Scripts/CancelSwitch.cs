using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelSwitch : MonoBehaviour
{
    public Button sbtn;
    public Button rbtn;
    public GameObject languamenue;
    private void OnEnable()
    {
        sbtn.interactable = false;
        rbtn.interactable = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelAndContinue();
        }
    }
    public void CancelAndContinue()
    {
        languamenue.SetActive(false);
    }
    private void OnDisable()
    {
        sbtn.interactable = true;
        rbtn.interactable = true;
    }
}
