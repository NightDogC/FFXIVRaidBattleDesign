using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IllustrationManager : MonoBehaviour
{
    public GameObject illusUI;
    private GameObject _illusUI;
    public void MEnter(string i)
    {
        _illusUI = Instantiate(illusUI, Input.mousePosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        RectTransform rect = _illusUI.GetComponent<RectTransform>();
        if (rect.anchoredPosition.x < 0)
        {
            rect.pivot += Vector2.left;
        }
        GetIllustration(i);
    }
    public void MExit()
    {
        Destroy(_illusUI);
    }
    private void GetIllustration(string illuskey)
    {
        LocalizationText a = _illusUI.GetComponentInChildren<LocalizationText>();
        a.key = illuskey;
        a.GenerateText();
    }
}


