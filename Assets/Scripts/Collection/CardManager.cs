using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{

    [Header("Trading Card")]
    [SerializeField] private GameObject namePlateText;
    [SerializeField] private GameObject sproutImage;
    [SerializeField] private GameObject statsText;

    public void SetCardContent(SproutData data)
    {

        TextMeshProUGUI namePlateTextComponent = namePlateText.GetComponent<TextMeshProUGUI>();
        namePlateTextComponent.text = $"{data.sName}";

        Image sproutImageComponent = sproutImage.GetComponent<Image>();
        sproutImageComponent.sprite = data.cardImage;

        TextMeshProUGUI statsTextComponent = statsText.GetComponent<TextMeshProUGUI>();
        statsTextComponent.text = $"{data.details}\nBirthday - {data.birthday}\nAge - {data.age}\nPersonality - {data.personality}\nFavorite Food - {data.favoriteFood}";
    }
}
