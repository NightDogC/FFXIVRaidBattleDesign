using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInput : MonoBehaviour
{
    public Animator animator;
    public KeyCode kc;
    public KeyCode kc2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(kc)|| Input.GetKeyDown(kc2))
        {
            animator.SetTrigger("input");
        }
    }
}
