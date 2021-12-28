using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerList;
    public List<GameObject> list { get => playerList; }

    void Start()
    {
        playerList.Add(null);
        playerList.Add(GameObject.Find("T1"));
        playerList.Add(GameObject.Find("T2"));
        playerList.Add(GameObject.Find("D1"));
        playerList.Add(GameObject.Find("D2"));
        playerList.Add(GameObject.Find("H1"));
        playerList.Add(GameObject.Find("H2"));
        playerList.Add(GameObject.Find("D3"));
        playerList.Add(GameObject.Find("D4"));
    }

}
