using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScene : MonoBehaviour
{
    /// <summary>
    /// Loads a given scene
    /// </summary>
    /// <param name="scene">the scene to load</param>
    public void LoadTheScene(string scene) 
    {
        SceneManager.LoadScene(scene); 
    }
}
