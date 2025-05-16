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
        public string phaseName;
        public bool isSelected;
        private Outline outline;

        public void SetOutline(Outline newOutline)
        {
            outline = newOutline;
        }

        public void EnableOutline(bool enable)
        {
            if (outline != null)
            {
                outline.enabled = enable;
            }
        }
    }

    [SerializeField] private List<PhaseGroup> phaseGroups = new List<PhaseGroup>();
    [SerializeField] private Button submitButton;
    [SerializeField] private TextMeshProUGUI resultsText;
    [SerializeField] private GameObject resultsPage;
    private PhaseGroup selectedPhase;

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

                // Add outline component
                Outline outline = phase.imageButton.gameObject.AddComponent<Outline>();
                outline.effectColor = Color.blue;
                outline.effectDistance = new Vector2(6, 6);
                outline.enabled = false;
                phase.SetOutline(outline);

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

    private void OnPhaseSelected(PhaseGroup phase)
    {
        // Deselect previous phase if any
        if (selectedPhase != null)
        {
            selectedPhase.isSelected = false;
            selectedPhase.EnableOutline(false);
        }

        // Select new phase
        phase.isSelected = true;
        phase.EnableOutline(true);
        selectedPhase = phase;
    }

    private void OnSubmitClicked()
    {
        if (selectedPhase != null)
        {
            // Update the results text with the fixed format
            if (resultsText != null)
            {
                resultsText.text = $"It's in the {selectedPhase.phaseName} Phase? That's good to know! The sprouts will add California Sunflower to their guest list. Thanks for your help!";
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
        }
    }

    public void ClearSelection()
    {
        if (selectedPhase != null)
        {
            selectedPhase.isSelected = false;
            selectedPhase.EnableOutline(false);
            selectedPhase = null;
        }
    }
} 