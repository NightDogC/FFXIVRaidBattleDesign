using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAction : MonoBehaviour
{

    public PlayerStatus anotherTank;
    public GameObject provokeEffect;
    public Toggle AutoToggle;
    private int skillcount;
    [SerializeField]
    private Timer timer;
    public bool isSubTank;
    void Start()
    {

    }
    void Update()
    {
        Timeline();
    }
    public void Provoke()
    {
        Instantiate(provokeEffect, this.gameObject.transform);
        anotherTank.tag = "Player";
        this.tag = "MainTank";
    }
    public void Timeline()
    {
        if (isSubTank&& timer.phaseTime > 92 && skillcount == 0)
        {
            skillcount++;
            Provoke();
            isSubTank = false;
        }
    }
}
