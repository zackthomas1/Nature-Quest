using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionUIManager : MonoBehaviour
{
    [SerializeField] private GameObject sproutBadgePrefab;
    [SerializeField] private Transform parentTransform; // Parent with Grid/Vertical Layout
    [SerializeField] private List<SproutData> sproutDataList;

    private List<GameObject> badgeList = new List<GameObject>();
    private int badgeListSize = 12;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBadges();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLocationScene()
    {
        Debug.Log("Closing collection. Load LocationScene");
        SceneManager.LoadScene("LocationScene");
    }

    public void SpawnBadges()
    {
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
        }
    }
}
