using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HomeMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject HelpPanel;
    [SerializeField] private GameObject WarningPanel;


    // Start is called before the first frame update
    void Start()
    {
        ShowHomePanel();
    }

    public void GoToScene(string sceneName)
    {
        Debug.LogFormat("Go to Scene {0}", sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void ShowHomePanel()
    {
        HomePanel.SetActive(true);
        HelpPanel.SetActive(false);
        WarningPanel.SetActive(false);
    }

    public void ShowHelpPanel()
    {
        HomePanel.SetActive(false);
        HelpPanel.SetActive(true);
        WarningPanel.SetActive(false);
    }

    public void ShowWarningPanel()
    {
        HomePanel.SetActive(false);
        HelpPanel.SetActive(false);
        WarningPanel.SetActive(true);
    }
}
