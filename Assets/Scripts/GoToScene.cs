using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScene : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private Collider2D collider2D;

    [SerializeField] private string scene;

    /// <summary>
    /// Loads a given scene
    /// </summary>
    /// <param name="scene">the scene to load</param>
    public void LoadTheScene(string scene) 
    {
        SceneManager.LoadScene(scene); 
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LoadTheScene(scene);
        }
    }
}
