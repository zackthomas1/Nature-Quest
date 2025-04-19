using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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
    [SerializeField] private GameObject BP;

    [Header("Page 3 Elements")]
    [SerializeField] private Text timerText;
    [SerializeField] private Button countButton;
    [SerializeField] private Image timerCircle;
    [SerializeField] private float gameDuration = 10f; // 10 seconds game duration FOR NOW

    [Header("Page 4 Elements")]
    [SerializeField] private Text resultText;

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
        ShowPage(1);
    }

    // Called by the "Next" button on Page 1 to move to Page 2.
    public void OnPage1Next()
    {
        Debug.Log("Clicked!");
        ShowPage(2);
    }

    // Called by the "Play Game" button on Page 2 to move to Page 3.
    public void OnPlayGameButton()
    {
        Debug.Log("Play Game button clicked");
        ShowPage(3);
        StartBirdGame();
    }

    // Called by the "Count bird call" button on Page 3.
    public void OnCountButtonPressed()
    {
        if (gameRunning)
        {
            countBirdCall++;
            Debug.Log("Count incremented: " + countBirdCall);
            // You could update UI count text if you want to display this in real time.
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
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        CG.SetActive(false);
        CW.SetActive(false);
        CQ.SetActive(false);
        RR.SetActive(false);
        TH.SetActive(false);
        ST.SetActive(false);
        BP.SetActive(false);


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
        // When time is up, transition to page 4 and show result.
        Debug.Log("Game over. Total counts: " + countBirdCall);
        resultText.text = "You counted: " + countBirdCall + " calls!";
        ShowPage(4);
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

    public void OnBlackPheobe()
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
        BP.SetActive(false);

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
                BP.SetActive(true);
                break;

        }
    }


}
