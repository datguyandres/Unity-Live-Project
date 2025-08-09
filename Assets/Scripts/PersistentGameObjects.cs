using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PersistentGameObjects : MonoBehaviour
{
    public GameManager gameManager;

    
    void Start()
    {
        //if there's another gamemanager OR if this scene shouldn't have one, destroy all the persistent objects
        if (!GameManager.Instance == this.gameManager) 
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
