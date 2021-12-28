using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormcloudAoE : MonoBehaviour
{
    public float lastingTime;
    public Timer timer;
    public float dotRate;
    private float dotCountDown;
    void Awake()
    {
        dotCountDown = 1;
    }
    private void Update()
    {
        dotCountDown -= Time.deltaTime;
        if (dotCountDown < 0)
        {
            StopCoroutine("DoTAoE");
            StartCoroutine("DoTAoE");
            dotCountDown = dotRate;
        }
        if (timer.phaseTime > lastingTime)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DoTAoE()
    {

        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        GetComponent<Collider2D>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        tag = collider.tag;
        if (tag == "MainTank" || tag == "Player")
        { collider.GetComponent<PlayerBuff>().playerDebuff.AddEcDebuff(30); }
    }
}
