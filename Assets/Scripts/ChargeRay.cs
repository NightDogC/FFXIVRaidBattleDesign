using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChargeRay : MonoBehaviour
{
    int layerMask = ~(1 << 9);
    public LineRenderer rayEffect;
    public int chargeCastTime;
    public int hyperchargeCastTime;
    public GameObject chargeHitEffect;
    private bool isChargeCasting;
    private RaycastHit2D hitObject;
    public bool trueEcho;
    public GameObject hyperchargeEffect;
    public GameObject hypercharge;
    public GameObject hyperchargeR;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private PlayerList playerList;
    [SerializeField]
    private List<int> ra;
    private int skillCount;
    void Awake()
    {
        isChargeCasting = false;
        rayEffect.SetPosition(0, transform.position);
        rayEffect.enabled = false;
        GenerateRandomArray();
    }

    void Update()
    {
        if (isChargeCasting == true)
        {
            Vector3 bossPosition = GameObject.FindGameObjectWithTag("Boss").transform.position;
            hitObject = Physics2D.Raycast(transform.position, bossPosition - transform.position, 40, layerMask);
            rayEffect.SetPosition(1, hitObject.collider.transform.position);
        }
        thisTimeline();
    }
    private void thisTimeline()
    {
        if (timer.phaseTime > 5 && skillCount == 0)
        {
            StartCoroutine("ChargeCasting", chargeCastTime);
            skillCount++;
        }
        if (timer.phaseTime > 11 && skillCount == 1)
        {
            StartCoroutine("HyperchargeCasting", hyperchargeCastTime);
            skillCount++;
        }
    }
    public IEnumerator ChargeCasting(int castTime)
    {
        isChargeCasting = true;
        rayEffect.enabled = true;
        yield return new WaitForSeconds(castTime);
        StartCoroutine("Charge");
    }
    public IEnumerator Charge()
    {
        tag = hitObject.transform.tag;
        GameObject effect = Instantiate(chargeHitEffect, hitObject.transform);
        if (tag == "MainTank" || tag == "Player")
        {
            hitObject.transform.GetComponent<PlayerBuff>().AddEcBuff(60);
        }
        else if (tag == "Boss")
        {
            hitObject.transform.GetComponent<BossAI>().AddEnhancedBuff();
            effect.transform.localScale = Vector3.one;
        }
        isChargeCasting = false;
        rayEffect.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(effect);
    }
    private IEnumerator HyperchargeCasting(int castTime)
    {
        if (trueEcho == true)
        {
            GetComponent<Animator>().SetTrigger("Hypercharge");
            hyperchargeEffect.SetActive(true);
            PositionHC();
            yield return new WaitForSeconds(castTime - 0.2f);
            hyperchargeEffect.GetComponent<Animator>().SetTrigger("GO");
            yield return new WaitForSeconds(0.2f);
            hyperchargeEffect.SetActive(false);
            StartCoroutine("Hypercharge");
        }
        else
        {
            yield return new WaitForSeconds(castTime);
            Destroy(this.gameObject);
        }

    }
    private IEnumerator Hypercharge()
    {
        bool ecBuffDetected = false;
        int i = 0;
        hypercharge.SetActive(true);
        hypercharge.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
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
            hypercharge.GetComponent<AoEhit>().damage = UnityEngine.Random.Range(45125, 49876);
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
        yield return new WaitForFixedUpdate();
        hyperchargeR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                Debug.Log($"Player{ra[i]}has detected ec Buff");
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
            hyperchargeR.GetComponent<AoEhit>().damage = UnityEngine.Random.Range(45125, 49876);
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
    private void PositionHC()
    {
        Vector3 bossPos = GameObject.FindGameObjectWithTag("Boss").transform.position;
        if (bossPos.y <= this.transform.position.y)
        {
            hypercharge.transform.Rotate(Vector3.forward, Vector3.Angle(Vector3.right, transform.position - bossPos));
        }
        else
        {
            hypercharge.transform.Rotate(Vector3.back, Vector3.Angle(Vector3.right, transform.position - bossPos));
        }
    }
}
