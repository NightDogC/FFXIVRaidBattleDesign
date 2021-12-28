using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIllustration : MonoBehaviour
{
    private void OnDisable()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("Illustration");
        foreach (var item in a)
        {
            Destroy(item);
        }
    }
}
