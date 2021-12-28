using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDebuff : MonoBehaviour
{
    public bool ecDebuff;
    public PlayerStatus playerStatus;
    public GameObject ecDebuffIcon;
    public Toggle autoToggle;
    public int doTdmg;
    void Start()
    {
        doTdmg = 17500;
    }
    public virtual void AddEcDebuff(int lastingTime)
    {
        StopCoroutine("EcBuffCountDown");
        StartCoroutine("EcDebuffCountDown", lastingTime);
    }
    public virtual void EndEcDebuff()
    {
        StopCoroutine("EcDebuffCountDown");
        ecDebuff = false;
        ecDebuffIcon.SetActive(false);
            GameObject.Find("Canvas/DebuffIcon").transform.Find("Electrocution_1").gameObject.SetActive(false);
            GameObject.Find("Canvas/DebuffIcon/CountDownText").GetComponent<Text>().text = null;
    }
    protected IEnumerator EcDebuffCountDown(int lastingTime)
    {
        ecDebuff = true;
        int i = 0;
        ecDebuffIcon.SetActive(true);
        do
        {
            i += 1;
            if (autoToggle.isOn)
            {
                GameObject.Find("Canvas/DebuffIcon").transform.Find("Electrocution_1").gameObject.SetActive(true);
                GameObject.Find("Canvas/DebuffIcon/CountDownText").GetComponent<Text>().text = (lastingTime - i + 1).ToString();
            }
            if (i % 3 == 2)
            {
                playerStatus.HpDecrease(BossAI.DamageType.DoT, DoTDmgCalc());
            }
            yield return new WaitForSeconds(1);
        } while (i < lastingTime && ecDebuff == true);
        EndEcDebuff();
        yield return 0;
    }
    private int DoTDmgCalc()
    {
        int i = Mathf.FloorToInt(Random.Range(doTdmg * 0.95f, doTdmg * 1.05f));
        return i;
    }

}
