using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerAction1 : MonoBehaviour
{
    [SerializeField]
    public PlayerList playerlist;
    public float baseHeal;
    public float globalCD;
    protected float _globalCD;
    public GameObject defaultSkill;
    protected void Start()
    {
        _globalCD = 10f;
    }
    protected void Update()
    {
        _globalCD -= Time.deltaTime;
        if (_globalCD < 0)
        {
            Invoke("DefaultSkill", 0);
            _globalCD = globalCD;
        }
    }
    protected void DefaultSkill()
    {
        Instantiate(defaultSkill, transform);
        for (int i = 1; i < 9; i++)
        {
            playerlist.list[i].GetComponent<PlayerStatus>().HpIncrease(Mathf.FloorToInt(UnityEngine.Random.Range(baseHeal * 0.95f, baseHeal * 1.05f)));
        }
    }

}
