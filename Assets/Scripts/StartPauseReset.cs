using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPauseReset : MonoBehaviour
{
    public int pauseTime;
    public Button sBtn;
    public Button rBtn;
    public Button cBtn;
    public Button eBtn;
    public GameObject result;
    private int rate;
    public List<GameObject> rateImg;
    public GameObject languagemenu;
    void Start()
    {
        Time.timeScale = 0;
        pauseTime = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!languagemenu.activeSelf)
        {
            StartAndPause();
        }
    }
    private bool isPause = true;
    public void StartAndPause()
    {
        pauseTime += 1;
        if (isPause)
        {
            Time.timeScale = 1;
            cBtn.interactable = false;
            eBtn.interactable = false;
        }
        else
        {
            Time.timeScale = 0;

            eBtn.interactable = true;
            cBtn.interactable = true;
        }
        isPause = !isPause;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void Result(int partyDeath, int dpsGrade)
    {
        result.SetActive(true);
        sBtn.interactable = false;
        rBtn.interactable = false;
        if (partyDeath ==0)
        {
            if (dpsGrade==0)
            {
                rate = 7;
            }
            else if(dpsGrade==1)
            {
                rate = 6;
            }
            else if (dpsGrade==2)
            {
                rate = 5;
            }
            else
            {
                rate = 4;
            }
        }
        else if (partyDeath <=3)
        {
            if (dpsGrade == 0)
            {
                rate = 6;
            }
            else if (dpsGrade == 1)
            {
                rate = 5;
            }
            else if (dpsGrade == 2)
            {
                rate = 4;
            }
            else
            {
                rate = 3;
            }
        }
        else if (partyDeath<=10)
        {
            if (dpsGrade<=1)
            {
                rate = 5;
            }
            else if (dpsGrade==2)
            {
                rate = 4;
            }
            else
            {
                rate = 3;
            }
        }
        else if (partyDeath <= 20)
        {
            if (dpsGrade <= 1)
            {
                rate = 4;
            }
            else if (dpsGrade == 2)
            {
                rate = 3;
            }
            else
            {
                rate = 2;
            }
        }
        else
        {
            if (dpsGrade <= 1)
            {
                rate = 3;
            }
            else if (dpsGrade == 2)
            {
                rate = 2;
            }
            else
            {
                rate = 1;
            }
        }
        if (pauseTime>1)
        {
            rate -= 2;
        }
        switch (rate)
        {
            case 7: { rateImg[rate].SetActive(true); break; }
            case 6: { rateImg[rate].SetActive(true); break; }
            case 5: { rateImg[rate].SetActive(true); break; }
            case 4: { rateImg[rate].SetActive(true); break; }
            case 3: { rateImg[rate].SetActive(true); break; }
            case 2: { rateImg[rate].SetActive(true); break; }
            case 1: { rateImg[rate].SetActive(true); break; }
            default:
                rateImg[0].SetActive(true); break;
        }
        StartAndPause();
    }
}

