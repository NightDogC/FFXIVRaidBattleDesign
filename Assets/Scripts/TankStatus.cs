using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStatus : PlayerStatus
{
    public Animator tankBurstEffect;
    protected override void  Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    public  override void HpDecrease(BossAI.DamageType dmgType, int damage)
    {
        int result;
        if (dmgType == BossAI.DamageType.Magical)
        {
            if (playerBuff.spBuff == true)
            {
                result = Mathf.FloorToInt(damage * 0.2f);
                hp -= result;
            }
            else
            {
                result = Mathf.FloorToInt(damage * 0.7f);
                hp -= result;
            }
        }
        else
        {
            result = damage;
            hp -= result;
            if (dmgType==BossAI.DamageType.TankBurst)
            {
                tankBurstEffect.SetTrigger("TankBurst");
            }
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
        _dmgText = Instantiate(dmgText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
        _dmgText.GetComponent<Text>().text = result.ToString();
        healtBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHp;
    }

}
