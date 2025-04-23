using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OptionSelectorManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public string descriptor;

    private bool isSelected;
    private float defaultMinSize; 
    private float defaultMaxSize;

    private WordAssociationUIManager wordAssociationUIManager;

    public void Initialize(string desc, WordAssociationUIManager manager)
    {
        descriptor = desc;
        wordAssociationUIManager = manager;
        isSelected = false;

        // Set default text mesh state
        TextMeshProUGUI textComponent = transform.Find("Button/Text")?.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = descriptor;
            textComponent.fontStyle = FontStyles.Normal;

            // Enable auto-sizing
            textComponent.enableAutoSizing = true;

            defaultMinSize = textComponent.fontSizeMin;
            defaultMaxSize = textComponent.fontSizeMax;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found on child named 'Text'.");
        }
    }

    public void UpdateSelection()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            SetSelectTextStyle();
            wordAssociationUIManager.AddDescriptorToSelections(descriptor.ToLower());
        }
        else
        {
            SetDeselectTextStyle();
            wordAssociationUIManager.RemoveDescriptorToSelections(descriptor.ToLower());
        }


    }

    private void SetSelectTextStyle()
    {
        TextMeshProUGUI textComponent = transform.Find("Button/Text")?.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = textComponent.text.ToUpper();
            textComponent.fontStyle = FontStyles.Bold;
            textComponent.fontSizeMin = defaultMinSize+8;
            textComponent.fontSizeMax = defaultMaxSize+8;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found on child named 'Text'.");
        }
    }

    private void SetDeselectTextStyle()
    {
        TextMeshProUGUI textComponent = transform.Find("Button/Text")?.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = textComponent.text.ToLower();
            textComponent.fontStyle = FontStyles.Normal;
            textComponent.fontSizeMin = defaultMinSize;
            textComponent.fontSizeMax = defaultMaxSize;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found on child named 'Text'.");
        }
    }




}
