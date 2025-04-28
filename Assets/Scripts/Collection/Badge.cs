using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour
{
    private CollectionUIManager menuUIManager;
    private SproutData sproutData;

    // Start is called before the first frame update
    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<CollectionUIManager>();
    }

    public void Unlock(SproutData data)
    {
        sproutData = data;

        Image buttonImageComponent = transform.Find("Button").GetComponent<Image>();
        Debug.Assert(buttonImageComponent != null, "Image component not found on child named 'Button'.");
        if (buttonImageComponent == null) return;

        buttonImageComponent.sprite = data.badgeImage;
    }

    public void OnClick()
    {
        if (sproutData == null)
        {
            Debug.Log("Badge locked. (sprout data NULL");
            return;
        }
        menuUIManager.DisplayTradingCardPanel(sproutData);
    }
}
