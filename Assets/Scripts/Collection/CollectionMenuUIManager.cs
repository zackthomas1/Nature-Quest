using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject CollectionPanel;
    [SerializeField] private GameObject TradingCardPanel;

    [Header("Badge")]
    [SerializeField] private Transform parentTransform; // Parent with Grid/Vertical Layout
    [SerializeField] private GameObject sproutBadgePrefab;

    [Header("Trading Card")]
    [SerializeField] private GameObject namePlateText;
    [SerializeField] private GameObject sproutImage;
    [SerializeField] private GameObject statsText;

    private List<GameObject> badgeList = new List<GameObject>();
    private int badgeListSize = 12;

    // Start is called before the first frame update
    void Start()
    {
        DisplayCollectioPanel();
        SpawnBadges();
    }

    public void LoadLocationScene()
    {
        Debug.Log("Closing collection. Load LocationScene");
        SceneManager.LoadScene("LocationScene");
    }

    public void SpawnBadges()
    {

        List<SproutData> unlockedSprouts = GameManager.Instance.unlockedSprouts;

        // Clear existing badges (if any)
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
        badgeList.Clear();

        const int itemsPerRow = 3;
        GameObject currentRow = null;
        // Instantiate badge prefabs
        for (int i = 0; i < badgeListSize; i++)
        {
            if (i % itemsPerRow == 0)
            {
                // start new row panel
                currentRow = new GameObject("RowPanel", typeof(RectTransform), typeof(HorizontalLayoutGroup));
                currentRow.transform.SetParent(parentTransform, false);

                HorizontalLayoutGroup layout = currentRow.GetComponent<HorizontalLayoutGroup>();
                layout.childForceExpandHeight = true;
                layout.childForceExpandWidth = true;
                layout.spacing = 25f;
            }

            GameObject badge = Instantiate(sproutBadgePrefab, currentRow.transform);
            badgeList.Add(badge);

            // Set image if sprout exists
            if (i < unlockedSprouts.Count)
            {
                badge.GetComponent<Badge>().Unlock(unlockedSprouts[i]);

                //int index = i; // Closure fix
                //badge.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowTradingCard(index));
            }
        }
    }

    public void DisplayCollectioPanel()
    {
        Debug.Log("Display Collection");
        CollectionPanel.SetActive(true);
        TradingCardPanel.SetActive(false);
    }

    public void DisplayTradingCardPanel(SproutData data)
    {
        Debug.Log("Display Trading Card");
        CollectionPanel.SetActive(false);
        TradingCardPanel.SetActive(true);

        TextMeshProUGUI namePlateTextComponent = namePlateText.GetComponent<TextMeshProUGUI>();
        namePlateTextComponent.text = $"{data.sName}";

        Image sproutImageComponent = sproutImage.GetComponent<Image>();
        sproutImageComponent.sprite = data.cardImage;

        TextMeshProUGUI statsTextComponent = statsText.GetComponent<TextMeshProUGUI>();
        statsTextComponent.text = $"{data.details}\nBirthday - {data.birthday}\nAge - {data.age}\nPersonality - {data.personality}\nFavorite Food - {data.favoriteFood}";


    }
}
