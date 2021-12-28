using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnController : MonoBehaviour
{
    public AudioSource bgm;
    public Slider volSlider;
    public void VolumnControl (Slider slider)
    {
        bgm.volume  = slider.value;

}
    
}
