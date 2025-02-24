using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject ScannerPanel_InRange;
    [SerializeField] private GameObject ScannerPanel_NotInRange;
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

    public void DisplayInRangePanel(int eventID)
    {
        if(isUIPanelActive == false)
        {
            tempEvent = eventID;
            ScannerPanel_InRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void OnJoinClick()
    {
        eventManager.ActivateEvent(tempEvent);
    }

    public void DisplayNotInRangePanel()
    {
        if(isUIPanelActive == false)
        {
            ScannerPanel_NotInRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void CloseButtonClick()
    {
        ScannerPanel_InRange.SetActive(false);
        ScannerPanel_NotInRange.SetActive(false);
        isUIPanelActive = false;
    }
}
