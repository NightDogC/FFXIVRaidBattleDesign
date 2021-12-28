using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCDDisplay : MonoBehaviour
{
    public float diff;
    public Image cover1;
    public Image cover2;
    public Image cover3;
    // Start is called before the first frame update

    void Update()
    {
        cover1.fillAmount = diff;
        cover2.fillAmount = diff;
        cover3.fillAmount = diff;
    }
}
