using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TriggerPauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;

    public GameObject MusicManager;
    public bool pauseState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!pauseScreen.activeInHierarchy)
            {
                pauseScreen.SetActive(true);                
                GameManager.Instance.PlayerCanMove = false;
                GameManager.Instance.Paused = true;
                /*if(MusicManager != null)
                {
                   MusicManager.GetComponent<MusicManager>().PauseMusic();
                }*/
                AudioListener.pause = true; 
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Should be disappearing");
        pauseScreen.SetActive(false);
        GameManager.Instance.PlayerCanMove = true;
        GameManager.Instance.Paused = false;
        AudioListener.pause = false;
        //MusicManager.GetComponent<MusicManager>().ResumeMusic();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
