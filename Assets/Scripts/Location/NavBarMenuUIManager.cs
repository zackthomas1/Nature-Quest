using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBarMenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadCollectionScene()
    {
        Debug.Log("Closing LocationScene. Load CollectionScene");
        SceneManager.LoadScene("CollectionScene");
    }
}
