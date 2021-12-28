using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRDetector : MonoBehaviour
{
    public int detectorIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.CompareTag("Player")||collider.CompareTag("MainTank")) && collider.GetComponent<PlayerBuff>().ecBuff==true)
        {
            collider.GetComponent<PlayerBuff>().tRecBuffDetect[detectorIndex] = true;
        }
    }
 }
