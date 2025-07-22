using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // This will carry data throughout our game and is callable throughtout every scene.

    public static GameManager Instance;

    public int DifficultyLevel = 1;

    [SerializeField] private float startTime = 100f;
    public float Timer = 0.0f;
    public float TimeLeft;

    public int PlayerScore;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public Vector3 PlayerLastLocation;

    public List<int> NpcsBeaten = new List<int>();

    public bool InLevel = false; // will be used to check if a playey just left a level to trigger certain dialogue

    public bool PlayerCanMove = true;

    public bool PlayerWon = false;

    public bool PlayerLost = false;

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

    public string[,] NpcWinLines = new string[2, 2] { //multi-dimensional array containing all player dialogue
            {"npc1 win line", "YOU WON YIPPEE" },
            {"npc2 win line", "YOU WON YIPPEE" }
        };


    public string[,] NpcLoseLines = new string[2, 1] { //multi-dimensional array containing all player dialogue
            {"Player + npc1 Lose line" },
            {"player + npc2 Lose line" }
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

        TimeLeft = startTime - Mathf.FloorToInt(Timer);

        TimerText.text = "Time Left: " + TimeLeft.ToString();

        ScoreText.text = "Score: " + PlayerScore.ToString();// how much time is left out of 5 minutes

        if (TimeLeft <= 0)
        {
            EndGame();
        }
        //Debug.Log("Time left: " + TimeLeft + "seconds"); if you want to see it real time but also viewable in editor

    }

    private void EndGame()
    {
        Application.Quit(); // for placeholder sake while we figure out how we want the timer ending to play out.
    }

}
