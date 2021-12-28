using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuff : MonoBehaviour
{
    public bool ecBuff;
    public bool spBuff;
    public bool ecBuffDetected;
    public GameObject ecBuffIcon;
    public GameObject spBuffIcon;
    public PlayerDebuff playerDebuff;
    public Toggle autoToggle;
    public GameObject ecBuffEffect;
    private GameObject _ecBuffEffect;
    public bool[] tRecBuffDetect;
    void Start()
    {
        ecBuff = false;
        spBuff = false;
        ecBuffDetected = false;
    }

    public virtual void AddEcBuff(int lastingTime)
    {
        if (ecBuff == true)
        {
            EndEcBuff();
            playerDebuff.AddEcDebuff(30);
        }
        else if (spBuff == true)
        {
            EndSpBuff();
            StartCoroutine("EcBuffCountDown", lastingTime);
        }
        else
        {
            StopCoroutine("EcBuffCountDown");
            StartCoroutine("EcBuffCountDown", lastingTime);
        }
    }
    public virtual void EndEcBuff()
    {
        StopCoroutine("EcBuffCountDown");
        ecBuff = false;
        Destroy(_ecBuffEffect);
        ecBuffIcon.SetActive(false);
            GameObject.Find("Canvas/BuffIcon").transform.Find("Electroconductivity").gameObject.SetActive(false);
            GameObject.Find("Canvas/BuffIcon/CountDownText").GetComponent<Text>().text = null;
    }
    protected IEnumerator EcBuffCountDown(int lastingTime)
    {
        ecBuff = true;
        yield return new WaitForSeconds(0.2f);
        _ecBuffEffect = Instantiate(ecBuffEffect,transform);
        int i = 0;
        ecBuffIcon.SetActive(true);
        do
        {
            i += 1;
            if (autoToggle.isOn)
            {
                GameObject.Find("Canvas/BuffIcon").transform.Find("Electroconductivity").gameObject.SetActive(true);
                GameObject.Find("Canvas/BuffIcon/CountDownText").GetComponent<Text>().text = (lastingTime - i + 1).ToString();
            }
            yield return new WaitForSeconds(1);
        } while (i < lastingTime && ecBuff == true);
        EndEcBuff();
        yield return 0;
    }
    public virtual void AddSpBuff()
    {
        EndEcBuff();
        StartCoroutine("SpBuffCountDown");
    }
    public virtual void EndSpBuff()
    {
        StopCoroutine("SpBuffCountDown");
        spBuff = false;
        spBuffIcon.SetActive(false);
        GameObject.Find("Canvas/BuffIcon").transform.Find("SurgeProtection").gameObject.SetActive(false);
        GameObject.Find("Canvas/BuffIcon/CountDownText").GetComponent<Text>().text = null;
    }
    protected IEnumerator SpBuffCountDown()
    {
        spBuff = true;
        int i = 0;
        spBuffIcon.SetActive(true);
        do
        {
            i += 1;
            if (autoToggle.isOn)
            {
                GameObject.Find("Canvas/BuffIcon").transform.Find("SurgeProtection").gameObject.SetActive(true);
                GameObject.Find("Canvas/BuffIcon/CountDownText").GetComponent<Text>().text = (4 - i).ToString();
            }
            yield return new WaitForSeconds(1);
        } while (i < 3 && spBuff == true);
        EndSpBuff();
        yield return 0;
    }
}
