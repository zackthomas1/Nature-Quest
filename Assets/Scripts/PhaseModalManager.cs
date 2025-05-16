using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PhaseModalManager : MonoBehaviour
{
    [System.Serializable]
    public class PhaseInfo
    {
        [SerializeField] public GameObject phaseObject;
        [SerializeField] public string phaseName;
        [SerializeField] public string phaseDescription;
        [SerializeField] public RawImage phaseImageDisplay; // The RawImage component to display the sprite
        [SerializeField] public Sprite phaseSprite; // The sprite that will populate the RawImage
    }

    [SerializeField] private GameObject modalPanel;
    [SerializeField] private RectTransform modalContent;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI phaseTitleText;
    [SerializeField] private TextMeshProUGUI phaseDescriptionText;
    [SerializeField] private List<PhaseInfo> phases = new List<PhaseInfo>();

    private void Start()
    {
        // Set up close button
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseModal);
        }

        // Set up phase buttons
        foreach (var phase in phases)
        {
            if (phase.phaseObject != null)
            {
                Button button = phase.phaseObject.GetComponent<Button>();
                if (button == null)
                {
                    button = phase.phaseObject.AddComponent<Button>();
                }

                // Create a local copy of the phase for the lambda
                PhaseInfo currentPhase = phase;
                button.onClick.AddListener(() => ShowPhaseModal(currentPhase.phaseName, currentPhase.phaseDescription, currentPhase.phaseImageDisplay, currentPhase.phaseSprite));
            }
        }

        // Initially hide the modal
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
        }
    }

    public void ShowPhaseModal(string phaseName, string phaseDescription, RawImage imageDisplay, Sprite sprite)
    {
        if (modalPanel != null)
        {
            // Update the modal content
            if (phaseTitleText != null)
            {
                phaseTitleText.text = phaseName;
            }

            if (phaseDescriptionText != null)
            {
                phaseDescriptionText.text = phaseDescription;
            }

            if (imageDisplay != null)
            {
                if (sprite != null)
                {
                    imageDisplay.texture = sprite.texture;
                    imageDisplay.gameObject.SetActive(true);
                }
                else
                {
                    imageDisplay.gameObject.SetActive(false);
                }
            }

            // Show the modal
            modalPanel.SetActive(true);
        }
    }

    public void CloseModal()
    {
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
        }
    }
} 