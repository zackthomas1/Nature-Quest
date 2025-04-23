using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WordAssociationUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject InstructionPanel;
    [SerializeField] private GameObject MiniGamePanel;
    [SerializeField] private GameObject SummaryPanel;

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


        MiniGamePanel.SetActive(true);
        InstructionPanel.SetActive(true);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(false);
    }

    public void ShowMiniGamePanel()
    {
        Debug.Log("Show mini game panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(true);
        SummaryPanel.SetActive(false);
    }

    public void ShowSummaryPanel()
    {
        Debug.Log("Show Summary Panel");
        InstructionPanel.SetActive(false);
        MiniGamePanel.SetActive(false);
        SummaryPanel.SetActive(true);

        string FormatList(List<string> items)
        {
            List<string> boldItems = items.Select(item => $"<b>{item}</b>").ToList();

            var allButLast = boldItems.Take(boldItems.Count - 1);
            var last = boldItems.Last();
            return $"{string.Join(", ", allButLast)}, and {last}";
        }

        TextMeshProUGUI textComponent = transform.Find("SummaryPanel/VerticalPanel/BodyPanel/ContentPanel/TextPanel/Text")?.GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogWarning("TextMeshProUGUI component not found on child named 'Text'.");
            return;
        }

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
        if (container == null)
        {
            Debug.LogWarning("BodyContainer GameObject not found on Canvas");
            return;
        }

        for (int i = 0; i < options.traits.Count; i++)
        {
            string trait = options.traits[i];

            // instantiate the prefab 
            GameObject instance = Instantiate(optionSelectorPrefab, container, false);

            // set selector text
            instance.GetComponent<OptionSelectorManager>().Initialize(trait, this);
            
            //
            //RectTransform rectTransform = instance.GetComponent<RectTransform>();
            //rectTransform.anchorMin = new Vector2(portion, 0.9f);
            //rectTransform.anchorMax = new Vector2(0.4f + portion, 1f);
            
        }
    }
}
