using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPhaseButton : MonoBehaviour
{
    [Header("Manager Components")]
    [SerializeField] private PhaseModalManager phaseModalManager;
    [SerializeField] private MatchingGameUIManager matchingGameUIManager;

    [Header("Phase Data")]
    [SerializeField] private string pname;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite image;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = icon;
    }

    public void ShowPhasesModal()
    {
        phaseModalManager.ShowPanel(pname, description, image);
    }

    public void SubmitSelection()
    {
        matchingGameUIManager.DisplayResults(pname);
    }
}
