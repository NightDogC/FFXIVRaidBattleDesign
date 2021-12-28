using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocallizationSwitcher : MonoBehaviour
{
    public GameObject languageMenu;
    public int rdytoswitchid;
    public void RdyToSwitchLanguage(int switchId)
    {
        languageMenu.transform.SetAsLastSibling();
        languageMenu.SetActive(true);
        rdytoswitchid = switchId;
    }
    public void SwitchLanguageAndReset()
    {
        LocalizationManager.instance.languageId = rdytoswitchid;
        languageMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
