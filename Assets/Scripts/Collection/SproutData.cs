using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SproutData", menuName = "Collection/SproutData")]

public class SproutData : ScriptableObject
{
    public string sName;
    public string birthday;
    public int age;
    public string description;
    public string personality;
    public string favoriteFood;
    public Sprite cardImage;
    public Sprite badgeImage;
}
