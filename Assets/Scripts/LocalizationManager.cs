using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    //单利模式前置
    public static LocalizationManager instance = null;
    //存放多语言的名字的列表
    private string[] languagelist;
    //指代上个列表的指定语言，也可以考虑用dictionary
    public int languageId;
    //存放语言资源的list
    private List<TextAsset> talist;
    //存放字典的list
    public List<Dictionary<string, string>> diclist;
    void Awake()
    {
        //简单的单例模式，用于确保场景切换时不被重置语言设置
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        //生成所需语言的名字的列表
        languagelist = new string[] { "English", "Chinese" };
        //实例化两个list，往语言对应的字典list里的字典里加载语言，并分割成key和value
        diclist = new List<Dictionary<string, string>>();
        talist = new List<TextAsset>();
        for (int i = 0; i < languagelist.Length; i++)
        {
            talist.Insert(i, Resources.Load<TextAsset>(languagelist[i]));
            diclist.Insert(i, new Dictionary<string, string>());
            string text = talist[i].text;
            string[] lines = text.Split('\n');
            foreach (string line in lines)
            {
                if (line == null)
                {
                    continue;
                }
                string[] keyAndValue = line.Split('=');
                diclist[i].Add(keyAndValue[0], keyAndValue[1]);
            }
        }
        SetLanguage(languageId);
    }
    public string GetValue(string key)
    {
        if (diclist[languageId] == null || diclist[languageId].ContainsKey(key) == false)
        {
            return null;
        }
        string value = null;
        diclist[languageId].TryGetValue(key, out value);
        return value;
    }
    public void SetLanguage(int id)
    {
        languageId = id;
        LocalizationText[] localizationTexts = Resources.FindObjectsOfTypeAll<LocalizationText>();
        foreach (var item in localizationTexts)
        {
            item.GenerateText();
        }
    }
}
