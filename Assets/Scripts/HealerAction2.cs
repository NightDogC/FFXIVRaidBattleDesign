using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerAction2 : MonoBehaviour
{
    [SerializeField]
    public PlayerList playerlist;
    public float baseHeal;
    public GameObject defaultSkill;
    public float globalCD;
    protected float _globalCD;
    private PlayerStatus maintank;
    public int healThreshold;
    protected void Start()
    {
        _globalCD = globalCD;
    }
    protected void Update()
    {
        _globalCD -= Time.deltaTime;
        for (int i = 1; i < 9; i++)
        {
            if (playerlist.list[i].CompareTag("MainTank"))
            {
                maintank = playerlist.list[i].GetComponent<PlayerStatus>();
                break;
            }
        }
        if (maintank.hp<healThreshold&& _globalCD<0)
        {
            _globalCD = globalCD;
            StartCoroutine("HealTank");
        }
    }
    protected IEnumerator HealTank()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(defaultSkill, transform);
        Instantiate(defaultSkill, maintank.transform);
        maintank.HpIncrease(Mathf.FloorToInt(UnityEngine.Random.Range(baseHeal * 0.95f, baseHeal * 1.05f)));
    }


}
