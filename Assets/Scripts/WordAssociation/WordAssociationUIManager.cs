using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WordAssociationUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject InstructionPanel;
    [SerializeField] private GameObject MiniGamePanel;
    [SerializeField] private GameObject SummaryPanel;

    [Header("Game Data")]
    [SerializeField] private PlantData currentPlant;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Word Association Minigame Start!");
        InstructionPanel.SetActive(true);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(false);
    }

    public void ShowMiniGamePanel()
    {
        Debug.Log("Show mini game panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(true);
        SummaryPanel.SetActive(false);
    }

    public void ShowSummaryPanel()
    {
        Debug.Log("Show Summary Panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(true);
    }

    public void LoadLocationScene()
    {
        Debug.Log("Closing mini-game. Load LocationScene");
        SceneManager.LoadScene("LocationScene");
    }

    public void ShowHelpPanel()
    {
        Debug.Log("Show Help Panel");
    }
}
