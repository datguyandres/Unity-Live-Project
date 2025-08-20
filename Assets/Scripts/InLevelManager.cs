using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevelManager : MonoBehaviour
{

    /// <summary>
    /// the current number of checkpoints the player has hit [deprecated]
    /// </summary>
    public int checkpointsHit;

    /// <summary>
    /// the number of checkpoints the player has missed
    /// </summary>
    public int checkpointsMissed;

    public int ExpressionScore; //score only for level to determine which expression to use

    /// <summary>
    /// the number of checkpoints the player needs to win the level
    /// </summary>
    public int checkpointsRequired;

    /// <summary>
    /// the number of checkpoints in this level
    /// </summary>
    public int totalCheckpoints;

    private void Start()
    {
        GameManager.Instance.PlayerCanMove = false;
    }

    public void StartTheLevel()
    {
        GameManager.Instance.PlayerCanMove = true;
    }

    /// <summary>
    /// end level and check score
    /// </summary>
    public void EndLevel()
    {
        if (checkpointsHit >= checkpointsRequired)
        {
            GameManager.Instance.PlayerWon = true;
            GameManager.Instance.DifficultyLevel++;
        }
        SceneManager.LoadScene(GameManager.Instance.playerLastScene);
    }
}
