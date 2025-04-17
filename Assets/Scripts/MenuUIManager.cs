using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject ExplorePanel_InRange;
    [SerializeField] private GameObject ExplorePanel_NotInRange;
    [SerializeField] private EventManager eventManager;
    bool isUIPanelActive;
    int tempEvent;

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

    public void DisplayInRangePanel(int eventID)
    {
        if(isUIPanelActive == false)
        {
            tempEvent = eventID;
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

    public void CloseExplorePanel()
    {
        ExplorePanel_InRange.SetActive(false);
        ExplorePanel_NotInRange.SetActive(false);
        isUIPanelActive = false;
    }
}
