using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // This will carry data throughout our game and is callable throughtout every scene.

    public static GameManager Instance;

    public int DifficultyLevel;

    public float Timer = 0.0f;
    public float TimeLeft;

    public int PlayerScore;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;
    
    // public string[] Npc1;
    //public string[] Npc2;

    public string[,] NpcLines = new string[2, 2] {  //multi-dimensional array containing all npc lines
            {"npc1 line1", "npc1 line2"},
            {"npc2 line1", "npc2 line2"}
        };
    public string[,] PlayerLines = new string[2, 2] { //multi-dimensional array containing all player dialogue
            {"Player + npc1 line1", "player + npc1 line2"},
            {"player + npc2 line1", "player + npc2 line2"}
        };

    private void Awake()
    {


        //NpcLines = new string[2, 2] {


        if (Instance != null) // makes sure we have only one instance of our main game manager
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; // makes it so that our class can be called anywhere without a reference
        DontDestroyOnLoad(gameObject); // prevents it from being destroyed on scene change


    }

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;

        TimeLeft = 300.0f - Mathf.FloorToInt(Timer);

        TimerText.text = "Time Left: " + TimeLeft.ToString();

        ScoreText.text = "Score: " + PlayerScore.ToString();// how much time is left out of 5 minutes
        //Debug.Log("Time left: " + TimeLeft + "seconds"); if you want to see it real time but also viewable in editor

    }

}
