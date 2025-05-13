
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class OptionSelectorManager : MonoBehaviour
{
    [Header("Cloud Objects")]
    [SerializeField] private GameObject CloudImage;
    [SerializeField] private GameObject CloudIcon;
    [SerializeField] private GameObject CloudText;

    [Header("Cloud State Sprites")]
    [SerializeField] private Sprite cloudSprite;
    [SerializeField] private Sprite cloudCorrectSprite;
    [SerializeField] private Sprite cloudWrongSprite;
    [SerializeField] private Sprite GreenCheckSprite;
    [SerializeField] private Sprite RedXSprite;

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
        TextMeshProUGUI textComponent = CloudText?.GetComponent<TextMeshProUGUI>();
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
        Image cloudImageComponent = CloudImage?.GetComponent<Image>();
        Debug.Assert(cloudImageComponent != null, "Image component not found on child named 'CloudImage'.");
        if (cloudImageComponent == null) return;

        // Set Cloud Icon image
        Image cloudIconComponent = CloudIcon?.GetComponent<Image>();
        Debug.Assert(cloudImageComponent != null, "Image component not found on child named 'CloudImage'.");
        if (cloudImageComponent == null) return;

        if (isSelectionCorrect)
        {
            cloudImageComponent.sprite = cloudCorrectSprite;
            CloudIcon.SetActive(true);
            cloudIconComponent.sprite = GreenCheckSprite;
        }
        else
        {
            cloudImageComponent.sprite = cloudWrongSprite;
            CloudIcon.SetActive(true);
            cloudIconComponent.sprite = RedXSprite;
        }
    }

    private void SetDeselectTextStyle()
    {
        // Set Cloud image
        Image cloudImageComponent = CloudImage?.GetComponent<Image>();
        Debug.Assert(cloudImageComponent != null, "Image component not found on child named 'CloudImage'.");
        if (cloudImageComponent == null) return;

        cloudImageComponent.sprite = cloudSprite;
        CloudIcon.SetActive(false);
    }
}
