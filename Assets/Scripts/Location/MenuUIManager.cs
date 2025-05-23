using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject OverlayBackgroundPanel;
    [SerializeField] private GameObject ExplorePanel_InRange;
    [SerializeField] private GameObject ExplorePanel_NotInRange;
    [SerializeField] private GameObject PrizePanel;
    [SerializeField] private GameObject CardPanel;

    bool isUIPanelActive;
    private string currentGameIdentifier; // Stores the mini-game scene name.

    // Start is called before the first frame update
    void Start()
    {

        OverlayBackgroundPanel.SetActive(false);
        ExplorePanel_InRange.SetActive(false);
        ExplorePanel_NotInRange.SetActive(false);

        // check if a sprout has been unlocked
        if (GameManager.Instance.isPrizePanelActive)
        {
            DisplayPrizePanel();
            CardPanel.GetComponent<CardManager>().SetCardContent(GameManager.Instance.prizeSprout);
        }
    }

    public void DisplayInRangePanel(string gameID)
    {
        if (!isUIPanelActive)
        {
            currentGameIdentifier = gameID;  // Save the game identifier
            OverlayBackgroundPanel.SetActive(true);
            ExplorePanel_InRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void DisplayNotInRangePanel()
    {
        if(isUIPanelActive == false)
        {
            OverlayBackgroundPanel.SetActive(true);
            ExplorePanel_NotInRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void DisplayPrizePanel()
    {
        PrizePanel.SetActive(true);
    }

    public void OnVisitClick()
    {
        ExplorePanel_InRange.SetActive(false);
        SceneManager.LoadSceneAsync(currentGameIdentifier, LoadSceneMode.Single);
    }

    public void CloseExplorePanel()
    {
        OverlayBackgroundPanel.SetActive(false);
        ExplorePanel_InRange.SetActive(false);
        ExplorePanel_NotInRange.SetActive(false);
        isUIPanelActive = false;
    }

    public void ClosePrizePanel()
    {
        PrizePanel.SetActive(false);
        GameManager.Instance.isPrizePanelActive = false;
    }

    public void ResetUIState()
    {
        isUIPanelActive = false;
    }
}
