using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;
    public Button otherAudioButton; // Add this

    private Image buttonImage;
    private Button thisButton;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        buttonImage.sprite = audioOffSprite;
    }

    public void OnClick()
    {
        if (!audioSource.isPlaying)
        {
            if (otherAudioButton != null)
                otherAudioButton.interactable = false;

            buttonImage.sprite = audioOnSprite;
            audioSource.Play();
            Invoke(nameof(ResetSprite), audioSource.clip.length); // or Invoke("ResetSprite", 5f);
        }
    }

    void ResetSprite()
    {
        buttonImage.sprite = audioOffSprite;

        if (otherAudioButton != null)
            otherAudioButton.interactable = true;
    }
}

