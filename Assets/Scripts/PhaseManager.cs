using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PhaseManager : MonoBehaviour
{
    [System.Serializable]
    public class PhaseGroup
    {
        public GameObject groupObject;
        public Image imageButton;
        public Outline outline;
        public bool isSelected;
        public string phaseName; // Add this to store the phase name
    }

    [SerializeField] private List<PhaseGroup> phaseGroups = new List<PhaseGroup>();
    [SerializeField] private Button submitButton; // Reference to the submit button
    [SerializeField] private TextMeshProUGUI resultsText; // Changed to TextMeshProUGUI
    [SerializeField] private GameObject resultsPage; // Reference to the results page
    private PhaseGroup currentlySelectedPhase;

    private void Start()
    {
        // Initialize all phase groups
        foreach (var phase in phaseGroups)
        {
            if (phase.imageButton != null)
            {
                // Add button component if not present
                Button button = phase.imageButton.GetComponent<Button>();
                if (button == null)
                {
                    button = phase.imageButton.gameObject.AddComponent<Button>();
                }

                // Add outline component if not present
                if (phase.outline == null)
                {
                    phase.outline = phase.imageButton.gameObject.AddComponent<Outline>();
                    phase.outline.effectColor = Color.yellow; // Default highlight color
                    phase.outline.effectDistance = new Vector2(2, 2);
                    phase.outline.enabled = false;
                }

                // Add click listener
                button.onClick.AddListener(() => OnPhaseSelected(phase));
            }
        }

        // Add submit button listener
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitClicked);
        }
    }

    private void OnPhaseSelected(PhaseGroup selectedPhase)
    {
        // If clicking the same phase, toggle selection
        if (currentlySelectedPhase == selectedPhase)
        {
            selectedPhase.isSelected = !selectedPhase.isSelected;
            selectedPhase.outline.enabled = selectedPhase.isSelected;
            if (!selectedPhase.isSelected)
            {
                currentlySelectedPhase = null;
            }
        }
        else
        {
            // Deselect previous phase if any
            if (currentlySelectedPhase != null)
            {
                currentlySelectedPhase.isSelected = false;
                currentlySelectedPhase.outline.enabled = false;
            }

            // Select new phase
            selectedPhase.isSelected = true;
            selectedPhase.outline.enabled = true;
            currentlySelectedPhase = selectedPhase;
        }
    }

    private void OnSubmitClicked()
    {
        if (currentlySelectedPhase != null)
        {
            // Update the results text
            if (resultsText != null)
            {
                resultsText.text = $"You have matched {currentlySelectedPhase.phaseName}";
            }

            // Show the results page
            if (resultsPage != null)
            {
                resultsPage.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Please select a phase before submitting");
            // You could add UI feedback here to tell the user to select a phase
        }
    }

    // Public method to get the currently selected phase
    public PhaseGroup GetSelectedPhase()
    {
        return currentlySelectedPhase;
    }

    // Public method to clear selection
    public void ClearSelection()
    {
        if (currentlySelectedPhase != null)
        {
            currentlySelectedPhase.isSelected = false;
            currentlySelectedPhase.outline.enabled = false;
            currentlySelectedPhase = null;
        }
    }
} 