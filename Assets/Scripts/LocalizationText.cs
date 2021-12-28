using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LocalizationText : MonoBehaviour
{
    public string key = " ";
    public Text text;
    public LocallizationSwitcher locallizationSwitcher;
    private void Start()
    {
        //text = GetComponent<Text>();
        //locallizationSwitcher = FindObjectOfType<LocallizationSwitcher>();
        //string localizedtext = locallizationSwitcher.GetValue(key);
        //text.text = localizedtext.Replace('|', '\n');
        GenerateText();
    }
    //private void OnEnable()
    //{
    //    GenerateText();
    //}
    public void GenerateText()
    {
        string localizedtext = LocalizationManager.instance.GetValue(key);
        text.text = localizedtext.Replace('|','\n');
    }
}   