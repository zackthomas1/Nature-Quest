using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject ExplorePanel_InRange;
    [SerializeField] private GameObject ExplorePanel_NotInRange;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private GameObject birdGameCanvas;
    bool isUIPanelActive;
    int tempEvent;
    private string currentGameIdentifier; // This will store "Bird" or "Oak" etc.

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void OnVisitClick()
    {
        //for now just testing bird
        if (currentGameIdentifier == "Bird")
        {
            //Debug.Log("Clicked!");
            // Close the current ExplorePanel
            ExplorePanel_InRange.SetActive(false);

            // Open the Bird Game UI.
            if (birdGameCanvas != null)
            {
                //Debug.Log("Clicked!");
                birdGameCanvas.SetActive(true);
            }
        }
        else
        {
            // Handle other game types (e.g., Oak game) if needed.
        }
    }

    public void CloseExplorePanel()
    {
        ExplorePanel_InRange.SetActive(false);
        ExplorePanel_NotInRange.SetActive(false);
        isUIPanelActive = false;
    }

    public void ResetUIState()
    {
        isUIPanelActive = false;
    }
}
