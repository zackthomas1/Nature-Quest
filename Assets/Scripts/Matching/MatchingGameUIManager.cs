using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MatchingGameUIManager : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private GameObject page1; //Home
    [SerializeField] private GameObject page2; //Instructions
    [SerializeField] private GameObject page3; //Game
    [SerializeField] private GameObject page4; //Results       

    [Header("Pages")]
    [SerializeField] private TextMeshProUGUI results;


    void Start()
    {
        // Show page 1 and hide others at start.
        ShowPage(1);
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

    public void LoadLocationScene()
    {
        Debug.Log("Closing mini-game. Load LocationScene");
        SceneManager.LoadScene("LocationScene");
    }

    public void DisplayResults(string phaseName)
    {
        results.text = $"It's in the {phaseName} Phase? That's good to know! The sprouts will add California Sunflower to their guest list. Thanks for your help!"; ;
        ShowPage(4);
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

}
