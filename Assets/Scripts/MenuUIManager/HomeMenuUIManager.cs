using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HomeMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject HelpPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        Debug.LogFormat("Go to Scene {0}", sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void SetActiveHelpPanel(bool isHelpPanelActive)
    {
        HomePanel.SetActive(!isHelpPanelActive);
        HelpPanel.SetActive(isHelpPanelActive);
    }
}
