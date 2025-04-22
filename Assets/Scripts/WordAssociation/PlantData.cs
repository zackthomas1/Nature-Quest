using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlantData", menuName = "Minigame/Plant Data")]
public class PlantData : ScriptableObject
{
    public string Name;
    public List<string> Traits;
}