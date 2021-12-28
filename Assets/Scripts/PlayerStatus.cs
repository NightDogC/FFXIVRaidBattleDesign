using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public int deathCount;
    public GameObject healtBar;
    public GameObject deathCountText;
    public GameObject ecMark;
    public PlayerBuff playerBuff;
    public GameObject thunderStorm;
    public GameObject lightningSurgeEffect;
    private GameObject _thunderStorm;
    public int tRIndex;
    public GameObject dmgText;
    protected GameObject _dmgText;
    public GameObject healText;
    protected GameObject _healText;

    protected virtual void Start()
    {
        playerBuff.playerDebuff.ecDebuff = false;
        ecMark.SetActive(false);
    }
    protected virtual void Update()
    {
        if (ecMark.activeSelf)
        {
            ecMark.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
        if (!(_dmgText == null))
        {
            _dmgText.transform.position = Camera.main.WorldToScreenPoint(transform.position)+new Vector3(25,0);
        }
        if (!(_healText == null))
        {
            _healText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(25, 0);
        }

    }
    public virtual void HpDecrease(BossAI.DamageType dmgType, int damage)
    {
        int result;
        if (dmgType == BossAI.DamageType.Magical && playerBuff.spBuff == true)
        {
            result= Mathf.FloorToInt(damage * 0.25f);
            hp -= result;
        }
        else
        {
            result = damage;
            hp -= damage;
        }
        if (hp <= 0)
        {
            hp = maxHp;
            deathCount += 1;
            deathCountText.GetComponent<DeathCount>().dC.text = deathCount.ToString();
            GameObject.Find("BossTargetRing").GetComponent<BossAI>().AddEnhancedBuff();
            playerBuff.EndEcBuff();
            playerBuff.playerDebuff.EndEcDebuff();
            playerBuff.EndSpBuff();
        }
        healtBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHp;
        _dmgText = Instantiate(dmgText, Camera.main.WorldToScreenPoint(transform.position),Quaternion.identity, GameObject.Find("Canvas").transform);
        _dmgText.GetComponent<Text>().text = result.ToString();
    }
    public virtual void HpIncrease(int heal)
    {
        hp += heal;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        healtBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHp;
        _healText = Instantiate(healText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
        _healText.GetComponent<Text>().text = heal.ToString();

    }
    public IEnumerator LSEffectOn()
    {
        GameObject _lightningSurgeEffect = Instantiate(lightningSurgeEffect, transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(_lightningSurgeEffect);
    }
    public IEnumerator ThunderStormOmen()
    {
        _thunderStorm = Instantiate(thunderStorm, transform.position, Quaternion.identity);
        _thunderStorm.GetComponent<ThunderStormAoE>().detector.detectorIndex = tRIndex;
        yield return new WaitForSeconds(3);
        _thunderStorm.GetComponent<ThunderStormAoE>().StartCoroutine("ThunderStorm");
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Detector") && playerBuff.ecBuff == true)
        {
            playerBuff.ecBuffDetected = true;
        }
        else if (collider.CompareTag("AOE"))
        {
            this.HpDecrease(BossAI.DamageType.Magical, collider.GetComponent<AoEhit>().damage);
        }

    }
}
