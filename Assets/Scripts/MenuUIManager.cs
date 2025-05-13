using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject ExplorePanel_InRange;
    [SerializeField] private GameObject ExplorePanel_NotInRange;
    [SerializeField] private GameObject PrizePanel;
    [SerializeField] private GameObject CardPanel;


    [Header("Event Manager")]
    [SerializeField] private EventManager eventManager;

    bool isUIPanelActive;
    int tempEvent;
    private string currentGameIdentifier; // This will store "Bird" or "Oak" etc.

    // Start is called before the first frame update
    void Start()
    {
        // check if a sprout has been unlocked
        if (GameManager.Instance.isPrizePanelActive)
        {
            DisplayPrizePanel();
            CardPanel.GetComponent<CardManager>().SetCardContent(GameManager.Instance.prizeSprout);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJoinClick()
    {
        eventManager.ActivateEvent(tempEvent);
    }

    public void DisplayInRangePanel(int eventID, string gameID)
    {
        if (!isUIPanelActive)
        {
            tempEvent = eventID;
            currentGameIdentifier = gameID;  // Save the game identifier
            ExplorePanel_InRange.SetActive(true);
            isUIPanelActive = true;
        }
    }


    public void DisplayNotInRangePanel()
    {
        if(isUIPanelActive == false)
        {
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
        if (currentGameIdentifier == "Bird")
        {
            ExplorePanel_InRange.SetActive(false);
            SceneManager.LoadSceneAsync("BirdGameScene", LoadSceneMode.Single);
        }
        else if (currentGameIdentifier == "Match")
        {
            ExplorePanel_InRange.SetActive(false);
            SceneManager.LoadSceneAsync("BirdGameScene", LoadSceneMode.Single);
        }
        else if (currentGameIdentifier == "Word")
        {
            ExplorePanel_InRange.SetActive(false);
            SceneManager.LoadSceneAsync("WordAssociationScene", LoadSceneMode.Single);
        }
    }

    public void CloseExplorePanel()
    {
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
