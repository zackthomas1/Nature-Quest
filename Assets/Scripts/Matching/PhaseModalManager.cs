using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PhaseModalManager : MonoBehaviour
{
    [Header("Associated UI Objects")]
    [SerializeField] private GameObject OverlayPanel;

    [Header("Display Fields")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI description;
    
    private void Start()
    {
        OverlayPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ShowPanel(string phaseName, string phaseDescription, Sprite phaseImg)
    {
        Debug.Log("Show phases modal panel");

        title.text = phaseName;
        description.text = phaseDescription;
        img.GetComponent<Image>().sprite = phaseImg;

        // Show the modal
        OverlayPanel.SetActive(true);
        gameObject.SetActive(true);
    }

    public void HideModal()
    {
        Debug.Log("Hide phases modal panel");
        OverlayPanel.SetActive(false);
        gameObject.SetActive(false);
    }
} 