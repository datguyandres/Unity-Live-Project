using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public InLevelManager levelManager;

    public PlayerController player;

    public CheckPointSetup checkpointHolder;
    public Slider healthBar;

    private void Start()
    {
        if (levelManager == null)
            levelManager = GameObject.FindGameObjectWithTag("InLevelManager").GetComponent<InLevelManager>();

        if (checkpointHolder == null)
            checkpointHolder = GameObject.FindGameObjectWithTag("CheckpointHolder").GetComponent<CheckPointSetup>();

        
        checkpointHolder.OnCheckpointMissed += UpdateHealthBar;
        player.HitObstacle += UpdateHealthBar;
    }

    /// <summary>
    /// sets the max value of the health bar to the number of shots the player has before they lose
    /// sets the current healthbar value
    /// </summary>
    private void UpdateHealthBar()
    {
        ///somehow this is being called over and over?
        healthBar.maxValue = levelManager.totalCheckpoints - levelManager.checkpointsRequired;
        healthBar.value = healthBar.maxValue - levelManager.checkpointsMissed;

        if(healthBar.maxValue - levelManager.checkpointsMissed < 1)
        {
            levelManager.EndLevel();
        }

        
    }
}
