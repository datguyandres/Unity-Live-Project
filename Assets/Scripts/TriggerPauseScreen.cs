using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPauseScreen : MonoBehaviour
{
    private KeyCode pauseKey = KeyCode.Escape;
    public GameObject pauseScreen;
    public bool pauseState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            pauseScreen.SetActive(true);
            GameManager.Instance.PlayerCanMove = false;
            GameManager.Instance.Paused = true;
        }
    }

    public void Resume()
    {
        Debug.Log("Should be disappearing");
        pauseScreen.SetActive(false);
        GameManager.Instance.PlayerCanMove = true;
        GameManager.Instance.Paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
