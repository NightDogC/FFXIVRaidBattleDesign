using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    public int bossMaxHp;
    public int bossHp;
    public int autoAttackDmg;
    public int autoDmgTake;
    public GameObject hpPercentage;
    public GameObject bossHealthBar;
    public GameObject castGauge;
    public BossMoveAI moveAI;
    private Animator attackAnime;
    public Image castGaugeFill;
    public GameObject buffIcon_Electrocharge;
    public Text buffIcon_EnhancedStack;
    public bool buff_Electrocharge;
    public GameObject buffIcon_Enhanced;
    public int buff_Enhanced;
    private int skillCount;
    private float castDiff;
    [SerializeField]
    private Timer timer;
    public PlayerList playerList;
    [SerializeField]
    private List<int> ra;
    public GameObject thunderStrike;
    private GameObject _thunderStrike;
    public GameObject thunderRoll;
    private GameObject _thunderRoll;
    public GameObject stepVoltageGenerator;
    public GameObject absorbEffect;
    public GameObject quote;
    [SerializeField]
    private List<Vector3> echoVecList;
    public GameObject echo;
    [SerializeField]
    private List<Vector3> stormcloudList;
    public GameObject stormcloud;
    public GameObject stormcloudOmen;
    public GameObject levinlance;
    public List<Vector3> levinlanceList;
    public bool innerSafe;
    public StartPauseReset result;
    /// <summary>
    /// 0在右上，1在左下
    /// </summary>
    public int cloudIndex;
    /// <summary>
    /// 0为9点，顺时针绕一圈，最多8，索引以目前BOSS技能配置为0~4（共5个）
    /// </summary>
    public int[] echoIndex;
    /// <summary>
    /// 4为顺时针，8为逆时针
    /// </summary>
    public int trueEchoIndex;
    public int spearIndex1;
    /// <summary>
    /// 分别代表第一个在0、3、6、9点
    /// </summary>
    public int spearIndex2;
    public GameObject dmgText;
    protected GameObject _dmgText;

    void Start()
    {
        attackAnime = transform.GetComponentInChildren<Animator>();
        buff_Electrocharge = false;
        buff_Enhanced = 0;
        InvokeRepeating("AutoAttack", 1.2f, 3f);
        InvokeRepeating("AutoDamageTake", 2.5f, 2.5f);
        GenerateRandomArray();
        castGauge.SetActive(false);
    }
    void Update()
    {

        Phase1TimeLine();
        if (castGauge.activeSelf)
        {
            moveAI.moveable = false;
            castGauge.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            castGaugeFill.fillAmount += castDiff * Time.deltaTime;
            if (castGaugeFill.fillAmount == 1)
            {
                castGauge.SetActive(false);
                castGaugeFill.fillAmount = 0;
                Invoke("MoveDelay", 2.2f);
            }
        }
        if (!(_dmgText == null))
        {
            _dmgText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(25, 0);
        }
    }
    private void MoveDelay()
    {
        moveAI.moveable = true;
    }
    public void AutoAttack()
    {
        if (!castGauge.activeSelf)
        {
            attackAnime.SetTrigger("Attack");
            GameObject.FindGameObjectWithTag("MainTank").GetComponent<PlayerStatus>().HpDecrease(DamageType.Physical, damageCalc(autoAttackDmg));
        }
    }
    public void AutoDamageTake()
    {
        float dps = UnityEngine.Random.Range(autoDmgTake * 0.95f, autoDmgTake * 1.05f);
        bossHp -= Mathf.FloorToInt(dps * (1 - buff_Enhanced * 0.05f));
        if (bossHp <= 0)
        {
            bossHp = 0;
        }
        float percentage = bossHealthBar.GetComponent<Image>().fillAmount = (float)bossHp / (float)bossMaxHp;
        hpPercentage.GetComponent<Text>().text = (Mathf.FloorToInt(percentage * 100)).ToString() + "%";
    }
    public void DamageTake(float damage)
    {
        if (!(damage==0))
        {
            int result = Mathf.FloorToInt(UnityEngine.Random.Range(damage * 0.95f, damage * 1.05f + 1) * (1 - buff_Enhanced * 0.05f));
            bossHp -= result;
            if (bossHp <= 0)
            {
                bossHp = 0;
            }
            _dmgText = Instantiate(dmgText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
            _dmgText.GetComponent<Text>().text = result.ToString();
            float percentage = bossHealthBar.GetComponent<Image>().fillAmount = (float)bossHp / (float)bossMaxHp;
            hpPercentage.GetComponent<Text>().text = (Mathf.FloorToInt(percentage * 100)).ToString() + "%";
        }

    }
    public void FillCastGauge(string skillName, float castTime, out float castDiff)
    {
        this.castGauge.SetActive(true);
        LocalizationText a = castGauge.GetComponentInChildren<LocalizationText>();
        a.key = skillName;
        a.GenerateText();
        castDiff = 1 / castTime;
    }
    public void AddEnhancedBuff()
    {
        if (buff_Enhanced < 8)
        {
            buff_Enhanced += 1;
        }
        buffIcon_Enhanced.SetActive(true);
        buffIcon_EnhancedStack.text = buff_Enhanced.ToString();
    }
    public void AddElectrochargeBuff()
    {
        buff_Electrocharge = true;
        buffIcon_Electrocharge.SetActive(true);
    }
    public void RemoveElectrochargeBuff()
    {
        buff_Electrocharge = false;
        buffIcon_Electrocharge.SetActive(false);
    }
    public int damageCalc(int baseDamage)
    {
        int dmg = Mathf.FloorToInt(UnityEngine.Random.Range(baseDamage * 0.95f, baseDamage * 1.05f + 1) * (1 + buff_Enhanced * 0.05f));
        return dmg;
    }
    private void Phase1TimeLine()
    {
        switch (skillCount)
        {
            case 0:
                if (timer.phaseTime > 6)
                {
                    this.skillCount++;
                    UnstableVoltageCasting(3, 3);
                }
                break;
            case 1:
                if (timer.phaseTime > 13)
                {
                    this.skillCount++;
                    float a = UnityEngine.Random.Range(0f, 1f);
                    if (a < 0.5f)
                    {
                        innerSafe = false;
                        StartCoroutine("ThunderStrikeCasting", 3);
                    }
                    else
                    {
                        innerSafe = true;
                        StartCoroutine("ThunderRollCasting", 3);
                    }
                }
                break;
            case 2:
                if (timer.phaseTime > 20)
                {
                    this.skillCount++;
                    AbsorbCasting(2);
                }
                break;
            case 3:
                if (timer.phaseTime > 24)
                {
                    this.skillCount++;
                    LightningSurgeCasting(3);
                }
                break;
            case 4:
                if (timer.phaseTime > 33)
                {
                    this.skillCount++;
                    float a = UnityEngine.Random.Range(0f, 1f);
                    if (a < 0.5f)
                    {
                        innerSafe = false;
                        StartCoroutine("DoubleStrikeCasting", 3);
                    }
                    else
                    {
                        innerSafe = true;
                        StartCoroutine("DoubleRollCasting", 3);
                    }
                }
                break;
            case 5:
                if (timer.phaseTime > 41)
                {
                    this.skillCount++;
                    JudgmentBlowCasting(4);
                }
                break;
            case 6:
                if (timer.phaseTime > 46)
                {
                    this.skillCount++;
                    Instantiate(stepVoltageGenerator, transform.position, Quaternion.identity);
                }
                break;

            case 7:
                if (timer.phaseTime > 51)
                {
                    UnstableVoltageCasting(4, 3);
                    this.skillCount++;
                }
                break;
            case 8:
                if (timer.phaseTime > 57)
                {
                    CloudstormCasting(2, 4);
                    this.skillCount++;
                }
                break;
            case 9:
                if (timer.phaseTime > 63)
                {
                    this.skillCount++;
                    Quote("echo");
                    SummonEcho(5);
                }
                break;
            case 10:
                if (timer.phaseTime > 66)
                {
                    StartCoroutine("ThunderStormCasting", 3);
                    skillCount++;
                }
                break;
            case 11:
                if (timer.phaseTime > 78)
                {
                    skillCount++;
                    AbsorbCasting(2);
                }
                break;
            case 12:
                if (timer.phaseTime > 82)
                {
                    skillCount++;
                    LightningSurgeCasting(3);
                }
                break;
            case 13:
                if (timer.phaseTime > 91)
                {
                    this.skillCount++;
                    JudgmentBlowCasting(4);
                }
                break;
            case 14:
                if (timer.phaseTime > 96)
                {
                    this.skillCount++;
                    Instantiate(stepVoltageGenerator, transform.position, Quaternion.identity);
                }
                break;
            case 15:
                if (timer.phaseTime > 98)
                {
                    skillCount++;
                    StartCoroutine("ThunderStormCasting", 3);
                }
                break;
            case 16:
                if (timer.phaseTime > 102)
                {
                    this.skillCount++;
                    float a = UnityEngine.Random.Range(0f, 1f);
                    if (a < 0.5f)
                    {
                        innerSafe = false;
                        StartCoroutine("DoubleStrikeCasting", 3);
                    }
                    else
                    {
                        innerSafe = true;
                        StartCoroutine("DoubleRollCasting", 3);
                    }
                }
                break;
            case 17:
                if (timer.phaseTime > 107)
                {
                    Quote("levinlance");
                    skillCount++;
                }
                break;
            case 18:
                if (timer.phaseTime > 109)
                {

                    StartCoroutine("SummonSpear", 1.5f);
                    skillCount++;
                }
                break;
            case 19:
                if (timer.phaseTime > 123)
                {
                    skillCount++;
                    int d = 0;
                    int g;
                    for (int i = 1; i < 9; i++)
                    {
                        d += playerList.list[i].GetComponent<PlayerStatus>().deathCount;
                    }
                    if (bossHp==0)
                    {
                        g = 0;
                    }
                    else if (bossHp<195000)
                    {
                        g = 1;
                    }
                    else if (bossHp<390000)
                    {
                        g = 2;
                    }
                    else
                    {
                        g = 3;
                    }
                    result.Result(d, g);
                }
                break;
            default:
                break;
        }
    }
    private IEnumerator SummonSpear(float summonInterval)
    {
        int k = 4 * UnityEngine.Random.Range(1, 3);
        spearIndex1 = k;
        int j = 3 * UnityEngine.Random.Range(0, 4);
        spearIndex2 = j;
        for (int i = 0; i < 3; i++)
        {
            int a = j + k * i;
            while (a >= 12)
            {
                a = a - 12;
            }
            Instantiate(levinlance, levinlanceList[a], Quaternion.identity);
            yield return new WaitForSeconds(summonInterval);
        }
    }
    private void CloudstormCasting(int summonAmount, int castTime)
    {
        FillCastGauge("cloudstorm", castTime, out castDiff);
        StartCoroutine((SummonStormcloud(summonAmount, castTime)));
    }
    private IEnumerator SummonStormcloud(int summonAmount, int castTime)
    {
        int k = UnityEngine.Random.Range(0, 2);
        cloudIndex = k;
        for (int i = 0; i < summonAmount; i++)
        {
            var a = Instantiate(stormcloudOmen, stormcloudList[2 * k + i], Quaternion.identity);
            a.GetComponent<DestroyCloud>().lastingTime = castTime;
            a.GetComponent<Animator>().SetTrigger("Omen");
        }
        yield return new WaitForSeconds(castTime);
        for (int i = 0; i < summonAmount; i++)
        {
            Instantiate(stormcloud, stormcloudList[2 * k + i], Quaternion.identity);
        }
    }
    private void Quote(string contentKey)
    {
        quote.SetActive(true);
        LocalizationText a = quote.GetComponentInChildren<LocalizationText>();
        a.key = contentKey;
        a.GenerateText();
    }
    private void SummonEcho(int summonAmount)
    {
        echoIndex = new int[summonAmount];
        for (int i = 0; i < summonAmount; i++)
        {
            var a = Instantiate(echo, echoVecList[ra[i] - 1], Quaternion.identity);
            if (i == 0)
            {
                a.GetComponent<ChargeRay>().trueEcho = true;
                trueEchoIndex = ra[i] - 1;
            }
            echoIndex[i] = ra[i] - 1;
        }
    }
    private IEnumerator ThunderStormCasting(int castTime)
    {
        FillCastGauge("thunderstorm", castTime, out castDiff);
        yield return new WaitForSeconds(castTime);
        for (int i = 1; i < 9; i++)
        {
            playerList.list[i].GetComponent<PlayerStatus>().StartCoroutine("ThunderStormOmen");
        }
    }
    private void UnstableVoltageCasting(int targetAmount, int castTime)
    {
        FillCastGauge("unstablevoltage", castTime, out castDiff);
        StartCoroutine(UnstableVoltage(targetAmount, castTime));
    }
    IEnumerator UnstableVoltage(int targetAmount, int castTime)
    {
        int[] tempArray = new int[targetAmount];
        for (int i = 0; i < targetAmount; i++)
        {
            int a = UnityEngine.Random.Range(1, 9);
            if (!tempArray.Contains(a))
            {
                tempArray[i] = a;
                playerList.list[tempArray[i]].GetComponent<PlayerStatus>().ecMark.SetActive(true);
            }
            else
            {
                i--;
            }
        }
        yield return new WaitForSeconds(castTime);
        for (int i = 0; i < targetAmount; i++)
        {
            playerList.list[tempArray[i]].GetComponent<PlayerStatus>().ecMark.SetActive(false);
            playerList.list[tempArray[i]].GetComponent<PlayerStatus>().HpDecrease(DamageType.Magical, damageCalc(15000));
            playerList.list[tempArray[i]].GetComponent<PlayerBuff>().AddEcBuff(60);
            yield return 1;
        }
    }
    IEnumerator ThunderStrikeCasting(int castTime)
    {
        FillCastGauge("thunderstrike", castTime, out castDiff);
        yield return new WaitForSeconds(castTime);
        StartCoroutine("ThunderStrike");
    }
    IEnumerator ThunderStrike()
    {
        bool ecBuffDetected = false;
        int i = 0;
        _thunderStrike = Instantiate(thunderStrike, transform.position, Quaternion.identity);
        _thunderStrike.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        _thunderStrike.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderRoll");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("ThunderRoll");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            _thunderStrike.GetComponent<AoEhit>().damage = damageCalc(30000);
            _thunderStrike.GetComponent<Animator>().SetTrigger("AOE");
            _thunderStrike.GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            _thunderStrike.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(_thunderStrike);
            Destroy(_thunderRoll);
        }
    }
    IEnumerator DoubleStrikeCasting(int castTime)
    {
        FillCastGauge("doublestrike", castTime, out castDiff);
        yield return new WaitForSeconds(castTime);
        StartCoroutine("DoubleStrike");
    }
    IEnumerator DoubleStrike()
    {
        bool ecBuffDetected = false;
        int i = 0;
        _thunderStrike = Instantiate(thunderStrike, transform.position, Quaternion.identity);
        _thunderStrike.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        _thunderStrike.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderRoll");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("ThunderRoll");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            _thunderStrike.GetComponent<AoEhit>().damage = damageCalc(30000);
            _thunderStrike.GetComponent<Animator>().SetTrigger("AOE");
            _thunderStrike.GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            _thunderStrike.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(_thunderStrike);
            Destroy(_thunderRoll);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine("ThunderRoll");
    }
    IEnumerator ThunderRollCasting(int castTime)
    {
        FillCastGauge("thunderroll", castTime, out castDiff);
        yield return new WaitForSeconds(castTime);
        StartCoroutine("ThunderRoll");
    }
    IEnumerator DoubleRollCasting(int castTime)
    {
        FillCastGauge("doubleroll", castTime, out castDiff);
        yield return new WaitForSeconds(castTime);
        StartCoroutine("DoubleRoll");
    }
    IEnumerator DoubleRoll()
    {
        bool ecBuffDetected = false;
        int i = 0;
        _thunderRoll = Instantiate(thunderRoll, transform.position, Quaternion.identity);
        _thunderRoll.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        _thunderRoll.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderStrike");
                yield return 0;
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                StartCoroutine("ThunderStrike");
                break;
            }
            i++;
        } while ((i < 8 && ecBuffDetected == false));
        if (ecBuffDetected == false)
        {
            _thunderRoll.GetComponent<AoEhit>().damage = damageCalc(30000);
            _thunderRoll.GetComponent<Animator>().SetTrigger("AOE");
            _thunderRoll.GetComponent<PolygonCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            _thunderRoll.GetComponent<PolygonCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(_thunderStrike);
            Destroy(_thunderRoll);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine("ThunderStrike");
    }
    IEnumerator ThunderRoll()
    {
        bool ecBuffDetected = false;
        int i = 0;
        _thunderRoll = Instantiate(thunderRoll, transform.position, Quaternion.identity);
        _thunderRoll.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        _thunderRoll.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("ThunderStrike");
                yield return 0;
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                StartCoroutine("ThunderStrike");
                break;
            }
            i++;
        } while ((i < 8 && ecBuffDetected == false));
        if (ecBuffDetected == false)
        {
            _thunderRoll.GetComponent<AoEhit>().damage = damageCalc(30000);
            _thunderRoll.GetComponent<Animator>().SetTrigger("AOE");
            _thunderRoll.GetComponent<PolygonCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            _thunderRoll.GetComponent<PolygonCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            Destroy(_thunderStrike);
            Destroy(_thunderRoll);
        }
    }
    private void AbsorbCasting(int castTime)
    {
        FillCastGauge("absorb", castTime, out castDiff);
        StartCoroutine("Absorb", castTime);
    }
    private IEnumerator Absorb(int castTime)
    {
        yield return new WaitForSeconds(castTime);
        absorbEffect.SetActive(true);
        for (int i = 1; i < 9; i++)
        {
            if (playerList.list[i].GetComponent<PlayerBuff>().ecBuff == true)
            {
                AddElectrochargeBuff();
                playerList.list[i].GetComponent<PlayerBuff>().ecBuff = false;
            }
        }
        yield return new WaitForSeconds(0.5f);
        absorbEffect.SetActive(false);
    }
    private void LightningSurgeCasting(int castTime)
    {
        FillCastGauge("lightningsurge", castTime, out castDiff);
        StartCoroutine("LightningSurge", castTime);
    }
    private IEnumerator LightningSurge(int castTime)
    {
        yield return new WaitForSeconds(castTime);
        for (int i = 1; i < 9; i++)
        {
            PlayerStatus t = playerList.list[i].GetComponent<PlayerStatus>();
            t.StartCoroutine("LSEffectOn");
            t.HpDecrease(DamageType.Magical, damageCalc(20000));
        }
        if (buff_Electrocharge == true)
        {
            for (int i = 1; i < 9; i++)
            {
                playerList.list[i].GetComponent<PlayerDebuff>().AddEcDebuff(30);
            }
            RemoveElectrochargeBuff();
        }
    }
    private void JudgmentBlowCasting(int castTime)
    {
        FillCastGauge("judgmentblow", castTime, out castDiff);
        StartCoroutine("JudgmentBlow", castTime);
    }
    private IEnumerator JudgmentBlow(int castTime)
    {
        var a = GameObject.FindGameObjectWithTag("MainTank");
        yield return new WaitForSeconds(castTime);
        a.GetComponent<PlayerBuff>().AddEcBuff(60);
        a.GetComponent<PlayerStatus>().HpDecrease(DamageType.TankBurst, damageCalc(28000));
    }
    public enum DamageType
    {
        Physical,
        Magical,
        DoT,
        TankBurst,
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
}
