using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class BirdGameUIManager : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private GameObject page1; //Bird Info
    [SerializeField] private GameObject page2; //Instructions
    [SerializeField] private GameObject page3; //Actual Game
    [SerializeField] private GameObject page4; //Results
    [SerializeField] private GameObject page5; //Reward Page
    [SerializeField] private GameObject CG;
    [SerializeField] private GameObject CW;
    [SerializeField] private GameObject CQ;
    [SerializeField] private GameObject RR;
    [SerializeField] private GameObject TH;
    [SerializeField] private GameObject ST;
    [SerializeField] private GameObject MB;

    [Header("Page 3 Elements")]
    [SerializeField] private Text timerText;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Button countButton;
    [SerializeField] private Image timerCircle;
    [SerializeField] private float gameDuration = 10f; // 10 seconds game duration FOR NOW

    [Header("Page 4 Elements")]
    [SerializeField] private TMP_Text result;
    [SerializeField] private Image xBirdsCalled;
    [SerializeField] private Image oneBirdCalled;
    [SerializeField] private Image zeroBirdsCalled;


    private float currentTime;
    private int countBirdCall = 0;
    private bool gameRunning = false;

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

    public void OnBack()
    {
        ShowPage(2);
    }

    // Called by the "Next" button on Page 1 to move to Page 2.
    public void OnPage1Next()
    {
        //Debug.Log("Clicked!");
        ShowPage(2);
    }

    // Called by the "Play Game" button on Page 2 to move to Page 3.
    public void OnPlayGameButton()
    {
        //Debug.Log("Play Game button clicked");
        ShowPage(3);
        StartBirdGame();
    }

    private void UpdateCountText()
    {
        if (countBirdCall == 1)
        {
            countText.text = $"I heard {countBirdCall} call!";
        }
        else
        {
            countText.text = $"I heard {countBirdCall} calls!";
        }
    }

    // Called by the "Count bird call" button on Page 3.
    public void OnCountButtonPressed()
    {
        if (gameRunning)
        {
            countText.text = "I heard 0 calls!";
            countBirdCall++;
            //Debug.Log("Count incremented: " + countBirdCall);
            UpdateCountText();
            // You could update UI count text if you want to display this in real time.
        }
    }

    public void OnUndoCallButtonPressed()
    {
        if (gameRunning && countBirdCall > 0)
        {
            countBirdCall--;
            //Debug.Log("Count decremented: " + countBirdCall);
            UpdateCountText();
        }
    }

    // Called by the "Next" button on Page 4 to move to Page 5.
    public void OnPage4Next()
    {
        ShowPage(5);
    }

    // Called by the "Back to Map" button on Page 5.
    public void OnBackToMap()
    {
        SceneManager.LoadScene("LocationScene", LoadSceneMode.Single);
        /*
        // Here you could simply disable the entire Bird Game UI
        // or transition back to your map view.
        gameObject.SetActive(false);
        MenuUIManager menuManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        if (menuManager != null)
        {
            menuManager.ResetUIState();
        }
        */
    }

    public void ShowPage(int pageNumber)
    {
        // Ensure all pages are disabled first.
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        CG.SetActive(false);
        CW.SetActive(false);
        CQ.SetActive(false);
        RR.SetActive(false);
        TH.SetActive(false);
        ST.SetActive(false);
        MB.SetActive(false);


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

    private void StartBirdGame()
    {
        currentTime = gameDuration;
        countBirdCall = 0;
        gameRunning = true;
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // Update the timer text
            timerText.text = Mathf.Ceil(currentTime).ToString();

            // Update the circular fill
            timerCircle.fillAmount = currentTime / gameDuration;

            yield return null;
        }

        // Final state
        timerText.text = "0 seconds";
        timerCircle.fillAmount = 0f;
        gameRunning = false;
        EndBirdGame();
    }


    private void EndBirdGame()
    {

        ShowPage(4);
        xBirdsCalled.gameObject.SetActive(false);
        oneBirdCalled.gameObject.SetActive(false);
        zeroBirdsCalled.gameObject.SetActive(false);

        if (countBirdCall == 0)
        {
            result.text = "0 calls? That’s good to know... I guess we shouldn’t form the choir. Thanks for your help!";
            zeroBirdsCalled.gameObject.SetActive(true); // Show the 0 birds called image
        }
        else if (countBirdCall == 1)
        {
            result.text = "1 call? That’s not enough for a choir... Good to know. Thanks for your help!";
            oneBirdCalled.gameObject.SetActive(true); // Show the 1 bird called image
        }
        else
        {
            result.text = $"{countBirdCall} calls? That’s a lot! Maybe we should form the choir after all. Thanks for your help!";
            xBirdsCalled.gameObject.SetActive(true); // Show the X birds called image
        }
    }

    public void OnCaliforniaGnatcatcher()
    {
        ShowBirdPage(1);
    }

    public void OnCactusWren()
    {
        ShowBirdPage(2);
    }
    public void OnCaliforniaQuail()
    {
        ShowBirdPage(3);
    }
    public void OnRoadRunner()
    {
        ShowBirdPage(4);
    }
    public void OnTailedHawk()
    {
        ShowBirdPage(5);
    }

    public void OnSpottedTowhee()
    {
        ShowBirdPage(6);
    }

    public void OnMockingbird()
    {
        ShowBirdPage(7);
    }


    public void ShowBirdPage(int pageNumber)
    {
        CG.SetActive(false);
        CW.SetActive(false);
        CQ.SetActive(false);
        RR.SetActive(false);
        TH.SetActive(false);
        ST.SetActive(false);
        MB.SetActive(false);

        switch (pageNumber)
        {
            case 1:
                CG.SetActive(true);
                break;
            case 2:
                CW.SetActive(true);
                break;
            case 3:
                CQ.SetActive(true);
                break;
            case 4:
                RR.SetActive(true);
                break;
            case 5:
                TH.SetActive(true);
                break;
            case 6:
                ST.SetActive(true);
                break;
            case 7:
                MB.SetActive(true);
                break;

        }
    }
    
    // General-purpose back buttons for each page
    public void OnBackFromPage2()
    {
        ShowPage(1); // Go back to Bird Info page
    }

    public void OnBackFromPage5()
    {
        ShowPage(4); // Go back to Results page
    }
    /*
    public void OnBackFromPage3()
    {
        ShowPage(2); // Go back to Instructions page
    }

    public void OnBackFromPage4()
    {
        ShowPage(3); // Go back to Game page
    }

    public void OnBackFromPage5()
    {
        ShowPage(4); // Go back to Results page
    }

    public void OnExitToMap()
    {
        SceneManager.LoadScene("LocationScene", LoadSceneMode.Single);
    }
    */
}
