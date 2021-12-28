using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DpsAction : MonoBehaviour
{
    public BossAI boss;
    [SerializeField]
    public PlayerList playerlist;
    public float basedmg;
    public float globalCD;
    protected float _globalCD;
    public Toggle autoToggle;
    protected string skillQueue;
    public GameObject defaultSkill;
    public GameObject skill1;
    public int skill1Potency;
    public GameObject skill2;
    public int skill2Potency;
    public GameObject skill3;
    public GCDDisplay gcddisplay;
    public int skill3Potency;
    public bool isMelee;
    protected Vector3 target;
    protected virtual void Start()
    {
            _globalCD = 1f;
            skillQueue = "NullSkill";

    }
    protected virtual void Update()
    {
        _globalCD -= Time.deltaTime;
        target = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>().position;
        float dist = Vector3.Distance(target, transform.position);
        if (autoToggle.isOn)
        {
            gcddisplay.diff = _globalCD/globalCD;
            if (_globalCD < 1f)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.J))
                {
                    skillQueue = "Skill1";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.K))
                {
                    skillQueue = "Skill2";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.L))
                {
                    skillQueue = "Skill3";
                }
            }
            if (_globalCD < 0 && dist < 6.5 + 18.5 * ((isMelee == true) ? 0 : 1))
            {
                Invoke(skillQueue,0);
            }
        }
        else
        {
            if (_globalCD < 0 && dist < 6.5 + 18.5 * ((isMelee == true) ? 0 : 1))
            {
                Invoke("DefaultSkill",0);
                _globalCD = globalCD;
            }
        }
    }
    protected void NullSkill()
    {
    }
    protected  void DefaultSkill()
    {
        skillQueue = "NullSkill";
        var a = Instantiate(defaultSkill, transform);
        if (isMelee)
        {
            if (target.x >= this.transform.position.x)
            {
                a.transform.RotateAround
                (transform.position, Vector3.back, Vector3.Angle(Vector3.up,target - transform.position));
            }
            else
            {
                a.transform.RotateAround
                (transform.position, Vector3.forward, Vector3.Angle(Vector3.up, target - transform.position));
            }
        }
    }
    protected virtual void Skill1()
    {

    }
    protected virtual void Skill2()
    {
    }
    protected virtual void Skill3()
    {
    }

}
