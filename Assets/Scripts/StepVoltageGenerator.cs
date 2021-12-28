using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StepVoltageGenerator : MonoBehaviour
{

    public GameObject stepVoltage;
    public GameObject stepVoltageR;
    [SerializeField]
    private PlayerList playerList;
    private List<int> ra;
    void Awake()
    {
        GenerateRandomArray();
        PositionSV();
        StartCoroutine("StepVoltage");
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
    private void PositionSV()
    {
        Vector3 mainTankPos = GameObject.FindGameObjectWithTag("MainTank").transform.position;
        if (mainTankPos.x >= this.transform.position.x)
        {
            stepVoltage.transform.RotateAround
            (transform.position, Vector3.back, Vector3.Angle(Vector3.up, mainTankPos - transform.position));
        }
        else
        {
            stepVoltage.transform.RotateAround
            (transform.position, Vector3.forward, Vector3.Angle(Vector3.up, mainTankPos - transform.position));
        }
    }
    private IEnumerator StepVoltage()
    {
        bool ecBuffDetected = false;
        int i = 0;
        stepVoltage.SetActive(true);
        stepVoltage.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        stepVoltage.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("StepVoltageR");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("StepVoltageR");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            stepVoltage.GetComponent<AoEhit>().damage = damageCalc(30000);
            stepVoltage.GetComponent<Animator>().SetTrigger("AOE");
            stepVoltage.GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            stepVoltage.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            stepVoltageR.SetActive(false);
            stepVoltage.SetActive(false);
        }
    }
    private IEnumerator StepVoltageR()
    {
        bool ecBuffDetected = false;
        int i = 0;
        stepVoltageR.SetActive(true);
        stepVoltageR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
        stepVoltageR.GetComponent<AoEhit>().EcDetector.GetComponent<Collider2D>().enabled = false;
        do
        {
            if (playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuff == true && playerList.list[ra[i]].GetComponent<PlayerBuff>().ecBuffDetected == true)
            {
                playerList.list[ra[i]].GetComponent<PlayerBuff>().AddSpBuff();
                ecBuffDetected = true;
                StopCoroutine("StepVoltage");
                for (int j = 1; j < 9; j++)
                {
                    playerList.list[j].GetComponent<PlayerBuff>().ecBuffDetected = false;
                }
                yield return 0;
                StartCoroutine("StepVoltage");
                break;
            }
            i++;
        } while (i < 8 && ecBuffDetected == false);
        if (ecBuffDetected == false)
        {
            stepVoltageR.GetComponent<AoEhit>().damage = damageCalc(30000);
            stepVoltageR.GetComponent<Animator>().SetTrigger("AOE");
            stepVoltageR.GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForFixedUpdate();
            stepVoltageR.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            stepVoltageR.SetActive(false);
            stepVoltage.SetActive(false);
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
