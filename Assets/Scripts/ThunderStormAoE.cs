using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormAoE : AoEhit
{
    public TRDetector detector;
    public GameObject thunderStormR;
    private GameObject _thunderStormR;
    public PlayerList playerList;

    private void Awake()
    {
        _thunderStormR = Instantiate(thunderStormR, transform.position, Quaternion.identity);
        GetComponent<Animator>().SetTrigger("Omen");
    }
    IEnumerator ThunderStorm()
    {
        _thunderStormR.GetComponentInChildren<TRDetector>().detectorIndex = detector.detectorIndex;
        bool ecBuffDetected = false;
        int i = 1;
        GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[i].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[i].GetComponent<PlayerBuff>().tRecBuffDetect[detector.detectorIndex] == true)
            {
                playerList.list[i].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderStormR");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().tRecBuffDetect[detector.detectorIndex] = false;
                }
                yield return 0;
                StartCoroutine("ThunderStormR");
                break;
            }
            i++;
        } while (i < 9 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            GetComponent<AoEhit>().damage = damageCalc(20000);
            GetComponent<Animator>().SetTrigger("AOE1");
            GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(1f);
            Destroy(_thunderStormR);
            Destroy(this.gameObject);
        }
    }
    IEnumerator ThunderStormR()
    {
        bool ecBuffDetected = false;
        int i = 1;
        _thunderStormR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        _thunderStormR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[i].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[i].GetComponent<PlayerBuff>().tRecBuffDetect[detector.detectorIndex] == true)
            {
                playerList.list[i].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderStorm");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().tRecBuffDetect[detector.detectorIndex] = false;
                }
                yield return 0;
                StartCoroutine("ThunderStorm");
                break;
            }
            i++;
        } while (i < 9 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            _thunderStormR.GetComponent<AoEhit>().damage = damageCalc(20000);
            _thunderStormR.GetComponent<Animator>().SetTrigger("AOE");
            _thunderStormR.GetComponent<PolygonCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            _thunderStormR.GetComponent<PolygonCollider2D>().enabled = false;
            yield return new WaitForSeconds(1f);
            Destroy(_thunderStormR);
            Destroy(this.gameObject);
        }
    }
    public int damageCalc(int baseDamage)
    {
        int dmg = Mathf.FloorToInt(UnityEngine.Random.Range
            (baseDamage * 0.95f, baseDamage * 1.05f + 1) * (1 +
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>().buff_Enhanced * 0.1f));
        return dmg;
    }
}
