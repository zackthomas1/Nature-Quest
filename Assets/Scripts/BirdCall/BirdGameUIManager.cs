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

    [Header("Page 3 Elements")]
    [SerializeField] private Text timerText;
    [SerializeField] private Button countButton;
    [SerializeField] private Image timerCircle;
    [SerializeField] private float gameDuration = 10f; // 10 seconds game duration FOR NOW

    [Header("Page 4 Elements")]
    [SerializeField] private TMP_Text result;
    [SerializeField] private Image xBirdsCalled;
    [SerializeField] private Image oneBirdCalled;
    [SerializeField] private Image zeroBirdsCalled;

    private GameObject currentActiveModal = null;
    private float currentTime;
    private int countBirdCall = 0;
    private bool gameRunning = false;

    void Start()
    {
        ShowPage(1);
    }

    public void ShowModal(GameObject modal)
    {
        Debug.Log("Show bird modal");
        modal.SetActive(true);
        currentActiveModal = modal;
    }

    public void HideModal()
    {
        Debug.Log("Hide bird modal");
        currentActiveModal?.SetActive(false);
        currentActiveModal = null;
        ShowPage(2);
    }

    // Called by the "Count bird call" button on Page 3.
    public void IncrementCallCountTotal()
    {
        if (gameRunning)
        {
            countBirdCall++;
            Debug.Log("Count incremented: " + countBirdCall);
        }
    }

    public void UnlockPrize(SproutData prizeSprout)
    {
        Debug.Assert(GameManager.Instance, "GameManager instance null");

        // Check if prize sprout should be unlocked
        if (GameManager.Instance && !GameManager.Instance.isSproutPreviouslyUnlocked(prizeSprout))
        {
            GameManager.Instance.UnlockSprout(prizeSprout);
            Debug.Log("Prize sprout unlocked");
        }
    }

    // Called by the "Back to Map" button on Page 5.
    public void LoadLocationScene()
    {
        Debug.Log("Closing mini-game. Load LocationScene");
        SceneManager.LoadScene("LocationScene", LoadSceneMode.Single);
    }

    public void ShowPage(int pageNumber)
    {
        // Ensure all pages are disabled first.
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);

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
            default:
                break;
        }
    }

    public void StartBirdGame()
    {
        Debug.Log("Game start");
        ShowPage(3);

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
            timerText.text = $"{Mathf.Ceil(currentTime).ToString()}s";

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
}
