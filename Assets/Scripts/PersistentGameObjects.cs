using UnityEngine;

public class PersistentGameObjects : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        if(!GameManager.Instance == this.gameManager)
        {
            Destroy(this);
        } else
        {
            DontDestroyOnLoad(this);
        }
    }
}
