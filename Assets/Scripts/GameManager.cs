using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("All Sprouts in the Game")]
    public List<SproutData> allSprouts = new List<SproutData>();

    [Header("Unlocked Sprouts")]
    public  List<SproutData> unlockedSprouts = new List<SproutData>();

    // Hidden public variables
    [HideInInspector] 
    public bool isPrizePanelActive = false;
    [HideInInspector]
    public SproutData prizeSprout; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return; 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UnlockSprout(SproutData data)
    {
        if(!unlockedSprouts.Contains(data))
        {
            unlockedSprouts.Add(data);
            Debug.Log($"Unlocked new sprout: {data.sName}");
        }

        isPrizePanelActive = true;
        prizeSprout = data; 
    }

    public bool isSproutPreviouslyUnlocked(SproutData data) 
    { 
        return unlockedSprouts.Contains(data);
    }
}
