using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMove : MoveBase
{
    public GameObject burstEffect;
    public float skilldmg;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        Vector3 current = this.GetComponent<Transform>().position;
        float dist = Vector3.Distance(target.position, current);
        if (dist > 1)
        {
            transform.position = Vector3.MoveTowards(current, target.position, Time.deltaTime * speed_move);
        }
        else
        {
            Instantiate(burstEffect,target);
            target.GetComponent<BossAI>().DamageTake(skilldmg);
            Destroy(this.gameObject);
        }
    }
}
