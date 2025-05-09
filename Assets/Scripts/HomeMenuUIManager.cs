using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HomeMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject HelpPanel;
    [Tooltip("The website URL to UCI Nature Preserve safety and rules page")]
    [SerializeField] private string url;


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
    }

    public void ShowHelpPanel()
    {
        HomePanel.SetActive(false);
        HelpPanel.SetActive(true);
    }

    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL is empty! Please assign a valid URL in the Inspector.");
        }
    }
}
