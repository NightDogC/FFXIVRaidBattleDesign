using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityMessenger : MonoBehaviour
{
    public PlayerList playerlist;
    public int chargeRandomSeed;
    void Start()
    {
        chargeRandomSeed = UnityEngine.Random.Range(2, 6);
    }

    void Update()
    {
        
    }
    public void EcPriority()
    {
        int j = 1;
        for (int i = 1; i < 9; i++)
        {
            if (playerlist.list[i].GetComponent<PlayerBuff>().ecBuff == true)
            {
                playerlist.list[i].GetComponent<PlayerMoveAI>().priority = j;
                j++;
            }
        }
    }
    public void NonEcPriority()
    {
        int j = 1;
        for (int i = 1; i < 9; i++)
        {
            if (playerlist.list[i].GetComponent<PlayerBuff>().ecBuff == false)
            {
                playerlist.list[i].GetComponent<PlayerMoveAI>().priority = j;
                j++;
            }
        }
    }
    public bool CheckOddEc()
    {
        int j = 0;
        for (int i = 1; i < 5; i++)
        {
            if (playerlist.list[i].GetComponent<PlayerBuff>().ecBuff == true)
            {
                j++;
            }
        }
        if (j%2==1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
