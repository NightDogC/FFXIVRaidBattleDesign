using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Levinlance : MonoBehaviour
{
    public int lanceChargeReadyTime;
    public int lanceChargeCastTime;
    public GameObject hyperchargeEffect;
    public GameObject hypercharge;
    public GameObject hyperchargeR;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private PlayerList playerList;
    private List<int> ra;
    private int skillCount;
    void Awake()
    {
        GenerateRandomArray();
    }

    void Update()
    {
        thisTimeline();
    }
    private void thisTimeline()
    {

        if (timer.phaseTime > lanceChargeReadyTime && skillCount == 0)
        {
            StartCoroutine("HyperchargeCasting", lanceChargeCastTime);
            skillCount++;
        }
    }
    private IEnumerator HyperchargeCasting(int castTime)
    {
        hyperchargeEffect.SetActive(true);
        PositionLC();
        yield return new WaitForSeconds(castTime);
        StartCoroutine("Hypercharge");
    }
    private IEnumerator Hypercharge()
    {
        bool ecBuffDetected = false;
        int i = 0;
        hypercharge.SetActive(true);
        hypercharge.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        hypercharge.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("HyperchargeR");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("HyperchargeR");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            hypercharge.GetComponent<AoEhit>().damage = UnityEngine.Random.Range(285000, 315001);
            hypercharge.GetComponent<Animator>().SetTrigger("AOE");
            hypercharge.GetComponent<Collider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            hypercharge.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator HyperchargeR()
    {
        bool ecBuffDetected = false;
        int i = 0;
        hyperchargeR.SetActive(true);
        hyperchargeR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        hyperchargeR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("Hypercharge");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("Hypercharge");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            hyperchargeR.GetComponent<AoEhit>().damage = UnityEngine.Random.Range(285000, 315001);
            hyperchargeR.GetComponent<Animator>().SetTrigger("AOE");
            hyperchargeR.GetComponent<Collider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            hyperchargeR.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
    private void GenerateRandomArray()
    {
        ra = new List<int>(8);
        int k = 0;
        do
        {
            k = UnityEngine.Random.Range(1, 9);
            if (!ra.Contains<int>(k))
            {
                ra.Add(k);
            }
        } while (ra.Count<int>() < 8);
    }
    private void PositionLC()
    {
        if (transform.position.y>0)
        {
            hypercharge.transform.Rotate(Vector3.forward, Vector3.Angle(Vector3.right, transform.position));
        }
        else
        {
            hypercharge.transform.Rotate(Vector3.back, Vector3.Angle(Vector3.right, transform.position));
        }
    }
}
