using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{

    Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Time.timeScale == 0))
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }
    }

}
