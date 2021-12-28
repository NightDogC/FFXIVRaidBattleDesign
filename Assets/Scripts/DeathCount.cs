using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{

    public Text dC;
    void Start()
    {
        dC = GetComponent<Text>();
    }

}
