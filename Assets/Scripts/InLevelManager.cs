using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevelManager : MonoBehaviour
{

    /// <summary>
    /// the current number of checkpoints the player has hit
    /// </summary>
    public int checkpointsHit;

    public int checkpointsMissed;

    public int ExpressionScore; //score only for level to determine which expression to use

    /// <summary>
    /// the number of checkpoints the player needs to win the level
    /// </summary>
    public int checkpointsRequired;

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
    public bool EndLevel()
    {
        Debug.Log("checkpoints hit" + checkpointsHit);
        if (checkpointsHit >= checkpointsRequired)
        {
            GameManager.Instance.PlayerWon = true;
            GameManager.Instance.DifficultyLevel++;
            return true;
        }
        else
        {
            GameManager.Instance.PlayerLost = true;
            return false;
        }
            SceneManager.LoadScene("TOPDOWNTEST");
    }
}
