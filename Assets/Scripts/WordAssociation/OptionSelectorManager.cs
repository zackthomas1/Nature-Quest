
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class OptionSelectorManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Cloud State Sprites")]
    [SerializeField] private Sprite cloudSprite;
    [SerializeField] private Sprite cloudCorrectSprite;
    [SerializeField] private Sprite cloudWrongSprite;

    private string descriptor;
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
        Debug.Assert(textComponent != null, "TextMeshProUGUI component not found on child named 'Text'.");
        if (textComponent == null ) return;

        textComponent.text = descriptor;
        textComponent.fontStyle = FontStyles.Normal;

        // Enable auto-sizing
        textComponent.enableAutoSizing = true;

        // 
        defaultMinSize = textComponent.fontSizeMin;
        defaultMaxSize = textComponent.fontSizeMax;
    }

    public void UpdateSelection()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            bool isSelectionCorrect = wordAssociationUIManager.IsSelectedOptionCorrect(descriptor);
            SetSelectTextStyle(isSelectionCorrect);
            wordAssociationUIManager.UpdateSelectionsSet(descriptor.ToLower());
        }
        else
        {
            SetDeselectTextStyle();
            wordAssociationUIManager.UpdateSelectionsSet(descriptor.ToLower());
        }
    }

    private void SetSelectTextStyle(bool isSelectionCorrect)
    {
        // Set Cloud image
        Image cloudImageComponent = transform.Find("Button/CloudImage").GetComponent<Image>();
        Debug.Assert(cloudImageComponent != null, "Image component not found on child named 'CloudImage'.");
        if (cloudImageComponent == null) return;

        if (isSelectionCorrect)
        {
            cloudImageComponent.sprite = cloudCorrectSprite;
        }
        else
        {
            cloudImageComponent.sprite = cloudWrongSprite;
        }
    }

    private void SetDeselectTextStyle()
    {
        // Set Cloud image
        Image cloudImageComponent = transform.Find("Button/CloudImage").GetComponent<Image>();
        Debug.Assert(cloudImageComponent != null, "Image component not found on child named 'CloudImage'.");
        if (cloudImageComponent == null) return;

        cloudImageComponent.sprite = cloudSprite;
    }
}
