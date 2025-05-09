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

        string FormatList(List<string> items)
        {
            List<string> boldItems = items.Select(item => $"<b>{item}</b>").ToList();

            var allButLast = boldItems.Take(boldItems.Count - 1);
            var last = boldItems.Last();
            return $"{string.Join(", ", allButLast)}, and {last}";
        }

        TextMeshProUGUI textComponent = transform.Find("SummaryPanel/VerticalPanel/BodyPanel/ContentPanel/TextPanel/Text")?.GetComponent<TextMeshProUGUI>();
        Debug.Assert(textComponent != null, "TextMeshProUGUI component not found on child named 'Text'.");
        if (textComponent == null) return;

        string traits = FormatList(currentSpecies.traits);

        if (IsSelectionCorrect())
        {
            textComponent.text = $"That’s right!!! {currentSpecies.commonName} has a {traits} texture.";
        }
        else
        {
            textComponent.text = $"Sorry, that is not correct. {currentSpecies.commonName} has a {traits} texture.";
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

    public void AddDescriptorToSelections(string descriptor)
    {
        if (!selections.Contains(descriptor))
        {
            selections.Add(descriptor);
        }
        Debug.Log("[" + String.Join(", ", selections) + "]");
    }

    public void RemoveDescriptorToSelections(string descriptor)
    {
        if (selections.Contains(descriptor))
        {
            selections.Remove(descriptor);
        }
        Debug.Log("[" + String.Join(", ", selections) + "]");
    }

    private bool IsSelectionCorrect()
    {
        return new HashSet<string>(selections).SetEquals(currentSpecies.traits);
    }

    private void SpawnOptionSelectors()
    {
        Transform container = transform.Find("WordAssociationPanel/VerticalPanel/BodyPanel/CloudPanel/VerticalPanel");
        Debug.Assert(container != null, "Container Panel GameObject not found on Canvas");
        if (container == null) return;

        const int itemsPerRow = 3;
        GameObject currentRow = null;
        for (int i = 0; i < options.traits.Count; i++)
        {
            if(i % itemsPerRow == 0)
            {
                // start new row panel
                currentRow = new GameObject("RowPanel", typeof(RectTransform), typeof(HorizontalLayoutGroup));
                currentRow.transform.SetParent(container, false);

                // Optional: Style row panel
                RectTransform rowRect = currentRow.GetComponent<RectTransform>();
                rowRect.sizeDelta = new Vector2 (0, 100);
            
                HorizontalLayoutGroup layout = currentRow.GetComponent<HorizontalLayoutGroup>();
                layout.childForceExpandHeight = true;
                layout.childForceExpandWidth = true;
                layout.spacing = 10f;
            }

            // Instantiate and initialize the OptionSelector
            GameObject instance = Instantiate(optionSelectorPrefab, currentRow.transform, false);
            instance.GetComponent<OptionSelectorManager>().Initialize(options.traits[i], this);            
        }
    }
}
