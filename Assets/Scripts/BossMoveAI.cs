using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMoveAI : MoveBase
{
    public bool moveable;
    public int ecPriority;
    protected override void Start()
    {
        moveable = true;
        base.Start();
    }
    protected override void Update()
    {
        Vector3 target = GameObject.FindGameObjectWithTag("MainTank").GetComponent<Transform>().position;
        Vector3 current = this.GetComponent<Transform>().position;
        float dist = Vector3.Distance(target, current);
        if (dist > 6.5 && moveable == true)
        {
            transform.position = Vector3.MoveTowards(current, target, Time.deltaTime * speed_move);
        }
    }
}
