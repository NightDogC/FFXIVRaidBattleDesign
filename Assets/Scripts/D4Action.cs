using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D4Action : DpsAction
{
    private int aether;
    [SerializeField]
    private List<Image> aetherImg;
    private bool enhanced;
    [SerializeField]
    private GameObject enhancedTip;
    protected override void Start()
    {
        base.Start();
        enhancedTip.SetActive(false);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Skill1()
    {
        skillQueue = "NullSkill";
        var a = Instantiate(skill1, transform);
        if (autoToggle.isOn)
        {
            a.GetComponent<EnergyMove>().skilldmg = skill1Potency * basedmg;
            _globalCD = globalCD;
            if (aether < 3)
            {
                aether++;
                AetherCharge();
            }
        }
    }
    protected override void Skill2()
    {
        skillQueue = "NullSkill";
        var a = Instantiate(skill2, transform);
        a.GetComponent<EnergyMove>().skilldmg = skill2Potency * basedmg;
        _globalCD = globalCD;
        float i = UnityEngine.Random.Range(0f, 1f);
        if (i < 0.4f || enhanced == true)
        {
            if (aether < 3)
            {
                aether++;
                AetherCharge();
            }
            enhanced = false;
            enhancedTip.SetActive(false);
        }
    }
    protected override void Skill3()
    {
        skillQueue = "NullSkill";
        Instantiate(skill3, boss.transform);
        if (aether == 1)
        {
            skill3Potency = 150;
        }
        else if (aether == 2)
        {
            skill3Potency = 250;
        }
        else if (aether == 3)
        {
            skill3Potency = 400;
            enhanced = true;
            enhancedTip.SetActive(true);
        }
        else
        {
            skill3Potency = 100;
        }
        boss.DamageTake(skill3Potency * basedmg);
        AetherConsume();
        _globalCD = globalCD;
    }
    private void AetherCharge()
    {
        if (aether == 1)
        {
            aetherImg[0].enabled = true;
        }
        else if (aether == 2)
        {
            aetherImg[0].enabled = true;
            aetherImg[1].enabled = true;
        }
        else if (aether == 3)
        {
            aetherImg[0].enabled = true;
            aetherImg[1].enabled = true;
            aetherImg[2].enabled = true;
        }
        else
        {
            aetherImg[0].enabled = false;
            aetherImg[1].enabled = false;
            aetherImg[2].enabled = false;
        }
    }
    private void AetherConsume()
    {
        aether = 0;
        aetherImg[0].enabled = false;
        aetherImg[1].enabled = false;
        aetherImg[2].enabled = false;
    }
}
