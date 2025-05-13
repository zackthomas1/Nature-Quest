using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WordAssociationUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject InstructionPanel;
    [SerializeField] private GameObject MiniGamePanel;
    [SerializeField] private GameObject SummaryPanel;
    [SerializeField] private GameObject HelpPanel;


    [Header("Game Data")]
    [SerializeField] private SpeciesData currentSpecies;
    [SerializeField] private OptionsData options;
    [SerializeField] private GameObject optionSelectorPrefab;

    [SerializeField] private GameObject summaryText;

    private List<string> selections = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Word Association Minigame Start!");

        SpawnOptionSelectors();
        ShowInstructionPanel();
    }
    public void ShowInstructionPanel()
    {
        Debug.Log("Show instruction panel");
        InstructionPanel.SetActive(true);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    public void ShowMiniGamePanel()
    {
        Debug.Log("Show mini game panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(true);
        SummaryPanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    public void ShowSummaryPanel()
    {
        Debug.Log("Show Summary Panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(true);
        HelpPanel.SetActive(false);

        // method to convert list of species traits to string
        string FormatList(List<string> items)
        {
            List<string> boldItems = items.Select(item => $"<b>{item}</b>").ToList();

            var allButLast = boldItems.Take(boldItems.Count - 1);
            var last = boldItems.Last();
            return $"{string.Join(", ", allButLast)}, and {last}";
        }

        // Generate title text component content
        TextMeshProUGUI textComponent = summaryText?.GetComponent<TextMeshProUGUI>();
        Debug.Assert(textComponent != null, $"TextMeshProUGUI component not found on child named '{summaryText.GetHierarchyPath()}'.");
        if (textComponent == null) return;

        string traits = FormatList(currentSpecies.traits);
        textComponent.text = $"You got it! the {currentSpecies.commonName} leaves are {traits}. Now the sprouts can finish their sign.";

        // Get Body transform container
        Transform container = transform.Find("SummaryPanel/VerticalPanel/BodyPanel/VerticalPanel");
        Debug.Assert(container != null, "Container Panel GameObject not found on Canvas");
        if (container == null) return;

        // Instantiate and initialize the OptionSelector
        for (int i = 0; i < currentSpecies.traits.Count; i++)
        {
            GameObject instance = Instantiate(optionSelectorPrefab, container.transform, false);
            instance.GetComponent<OptionSelectorManager>().Initialize(currentSpecies.traits[i], this);
        }
    }

    public void ShowHelpPanel()
    {
        HelpPanel.SetActive(true);
        Debug.Log("Show Help Panel");
    }

    public void LoadLocationScene()
    {
        Debug.Log("Closing mini-game. Load LocationScene");
        SceneManager.LoadScene("LocationScene");
    }

    public void UpdateSelectionsSet(string descriptor)
    {
        if (!selections.Contains(descriptor))
        {
            selections.Add(descriptor);
        }
        else
        {
            selections.Remove(descriptor);
        }

        Debug.Log("[" + String.Join(", ", selections) + "]");


        // Check if user has selected all the correct traits
        bool IsSelectionsSetCorrect = new HashSet<string>(currentSpecies.traits).SetEquals(new HashSet<string>(selections));
        if (IsSelectionsSetCorrect)
        {
            Debug.Log("Selections set correct");
            ShowSummaryPanel();
        }

    }

    public bool IsSelectedOptionCorrect(string selectedOption)
    {
        return currentSpecies.traits.Contains(selectedOption);
    }

    private void SpawnOptionSelectors()
    {
        // Get transform container
        Transform container = transform.Find("WordAssociationPanel/VerticalPanel/BodyPanel/CloudPanel");
        Debug.Assert(container != null, "Container Panel GameObject not found on Canvas");
        if (container == null) return;

        // Generate rows
        GameObject currentRow = null;
        for (int i = 0; i < options.traits.Count; i++)
        {
            // start new row panel
            currentRow = new GameObject("RowPanel", typeof(RectTransform), typeof(HorizontalLayoutGroup));
            currentRow.transform.SetParent(container, false);

            // Optional: Style row panel
            RectTransform rowRect = currentRow.GetComponent<RectTransform>();
            rowRect.sizeDelta = new Vector2(0, 100);

            HorizontalLayoutGroup layout = currentRow.GetComponent<HorizontalLayoutGroup>();

            // 
            layout.childForceExpandWidth = true;
            layout.childControlWidth = true;

            // altnerate alignment left/right based on row index
            bool leftSide = (i % 2 == 0); 
            layout.childAlignment = leftSide ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

            // give padding so cloud isn't flush with edge 
            int sidePadding = 40;
            if (leftSide)
            {
                layout.padding = new RectOffset(sidePadding, 0, 5, 5);
            }
            else
            {
                layout.padding = new RectOffset(0, sidePadding, 5, 5);
            }


            if (!leftSide)
            {
                AddFlexibleFiller(currentRow.transform);
            }

            // Instantiate and initialize the OptionSelector
            GameObject instance = Instantiate(optionSelectorPrefab, currentRow.transform, false);
            instance.GetComponent<OptionSelectorManager>().Initialize(options.traits[i], this);

            if (leftSide)
            {
                AddFlexibleFiller(currentRow.transform);
            }
        }
    }


    private void AddFlexibleFiller(Transform parent)
    {
        GameObject filler = new GameObject("Filler", typeof(RectTransform));
        filler.transform.SetParent(parent, false);
        LayoutElement layoutElem =  filler.AddComponent<LayoutElement>();
        layoutElem.flexibleWidth = 1;
    }
}
