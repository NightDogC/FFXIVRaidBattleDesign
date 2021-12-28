using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenEnter : MonoBehaviour
{
    public LocallizationSwitcher locallizationSwitcher;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            locallizationSwitcher.SwitchLanguageAndReset();
        }
    }
}
