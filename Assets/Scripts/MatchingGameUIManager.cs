using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MatchingGameUIManager : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private GameObject page1; //Instructions
    [SerializeField] private GameObject page2; //Actual Game
    [SerializeField] private GameObject page3; //Nothing        (Results)
    [SerializeField] private GameObject page4; //Results        (Reward)
    [SerializeField] private GameObject page5; //Reward Page    (Nothing)

    private void OnEnable()
    {
        // Reset to the first page every time this UI is enabled.
        ShowPage(1);
    }

    void Start()
    {
        // Show page 1 and hide others at start.
        ShowPage(1);
    }

    // Called by the "Next" button on Page 1 (Instructions) to move to Page 2 (Game).
    public void OnPlayGameButton() //Change to OnPlayGameButton
    {
        Debug.Log("Clicked!");
        ShowPage(2);
    }

    // Called by the "Play Game" button on Page 2 to move to Page 3.
    public void OnSelectImageButton() //Wont need a button here, it will be matching an image so you would click an image
    {
        Debug.Log("Play Game button clicked");
        ShowPage(4);
    }

    // Called by the selected image button on Page 4 to move to Page 5.
    public void OnPage4Next()
    {
        ShowPage(5);
    }

    // Called by the "Back to Map" button on Page 5.
    public void OnBackToMap()
    {
        // Here you could simply disable the entire Bird Game UI
        // or transition back to your map view.
        gameObject.SetActive(false);
        MenuUIManager menuManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        if (menuManager != null)
        {
            menuManager.ResetUIState();
        }
    }

    public void ShowPage(int pageNumber)
    {
        // Ensure all pages are disabled first.
        page1.SetActive(false);
        page2.SetActive(false);
        //page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);

        // Activate the requested page.
        switch (pageNumber)
        {
            case 1:
                page1.SetActive(true);
                break;
            case 2:
                page2.SetActive(true);
                break;
            case 3:
                page3.SetActive(true);
                break;
            case 4:
                page4.SetActive(true);
                break;
            case 5:
                page5.SetActive(true);
                break;
            default:
                break;
        }
    }

}
