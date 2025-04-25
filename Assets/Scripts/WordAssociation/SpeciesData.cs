using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpeciesData", menuName = "Minigames/Word Association/SpeciesData")]
public class SpeciesData : ScriptableObject
{
    public string commonName;
    public string scientificName;
    public List<string> traits;
}