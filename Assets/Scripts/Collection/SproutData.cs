using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SproutData", menuName = "Collection/SproutData")]

public class SproutData : ScriptableObject
{
    public Sprite badgeImage;
    public Sprite cardImage;
    public string sName;
    public string details;
    public string birthday;
    public string age;
    public string personality;
    public string favoriteFood;

}
