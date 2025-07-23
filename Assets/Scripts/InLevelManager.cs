using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevelManager : MonoBehaviour
{

    public int LevelScore { get; set; }

    public int ReqScore { get; set; }

    private void Start()
    {
        // make sure theres only one of these guys
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// end level and check score
    /// </summary>
    public void EndLevel()
    {
        if (LevelScore > ReqScore)
        {
            GameManager.Instance.PlayerWon = true;
            GameManager.Instance.DifficultyLevel++;
        } else
        {
            GameManager.Instance.PlayerLost = true;
        }
            SceneManager.LoadScene("TOPDOWNTEST");
    }
}
