using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PersistentGameObjects : MonoBehaviour
{
    public GameManager gameManager;

    
    void Awake()
    {
        //if there's another gamemanager OR if this scene shouldn't have one, destroy all the persistent objects
        if (!GameManager.Instance == this.gameManager) 
        {
            GameManager.Instance = null;
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
