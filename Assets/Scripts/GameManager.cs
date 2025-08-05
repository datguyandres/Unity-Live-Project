using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // This will carry data throughout our game and is callable throughtout every scene.

    public static GameManager Instance;

    /// <summary>
    /// The current level
    /// </summary>
    public int DifficultyLevel = 1;

    [SerializeField] private float startTime = 100f;
    public float Timer = 0.0f;
    public float TimeLeft;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public bool Paused { get; set; } //set to public because if we are using this to stop the timer then i need to be able to access it when dialogue starts so timer stops
    private KeyCode pauseKey = KeyCode.Escape;

    public GameObject FriendCounterUI;


    //below variables aren't actually used in this script, im guessing they're here for convenience?

    public Vector3 PlayerLastLocation;

    public string playerLastScene;

    public List<int> NpcsBeaten = new List<int>();

    public bool InLevel = false; // will be used to check if a playey just left a level to trigger certain dialogue

    public bool PlayerCanMove = true;

    public bool PlayerWon = false;

    public bool PlayerLost = false;

    [SerializeField] private string endScreen = "EndScreen";

    // public string[] Npc1;
    //public string[] Npc2;

    public string[,] NpcLines = new string[2, 5] {  //multi-dimensional array containing all npc lines
            {"Amica, aren’t you excited for this lab?", "Uh, I actually didn’t hear all of the instructions ’cause I was late.", "Oh, don’t worry, I'll help you through it!", "Follow my lead, and I'm sure you'll have fun!", "ur momma"},
            {"npc2 line1", "npc2 line2", "npc2 line3", "npc2 line4", "npc2 line 5"}
        };
    public string[,] PlayerLines = new string[2, 2] { //multi-dimensional array containing all player dialogue
            {"*sigh*, A week into school and I still haven’t gotten used to how loud it is.", "Well, just gotta get to bio, should just be the near door to the right."},
            {"Looks like there's only one open seat, in the back of the class.", "I do wonder who that is sitting there though, didn’t see him here last week."}
        };

    public string[,] NpcWinLines = new string[2, 5] { //multi-dimensional array containing all player dialogue
            {"Hmmm, it looks like plants A and D have spikier leaves compared to B and C’s rounder ones.", "Plants C and D are the same oliveish color though, maybe that makes them a pair?", "Oh, I think those two were just left in the sun too long,they were probably originally green like the others.", "Ok, so we’re sticking with A&D as a pair and B&C as a pair, right?", "Yeah, I’ll go turn in the submission paper then, we’ll get our results tomorrow!" },
            {"z", "YOU WON YIPPEE", "a", "b", "c"}
        };


    public string[,] NpcLoseLines = new string[2, 1] { //multi-dimensional array containing all player dialogue
            {"Oh, that one didn't work, maybe give it another try." },
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
        if (Input.GetKeyDown(pauseKey))
        {
            //TODO: Make the pausing work for more than just the timer. have it show pause screen, have it stop player movement.
            Paused = !Paused;
        }

        if (!Paused)
        {
            Timer += Time.deltaTime;

            TimeLeft = startTime - Mathf.FloorToInt(Timer);


            TimerText.text = TimeLeft.ToString();

            if (TimeLeft <= 0)
            {
                EndGame();
            }
            //Debug.Log("Time left: " + TimeLeft + "seconds"); if you want to see it real time but also viewable in editor
        }
        else
        {

        }

    }

    /// <summary>
    /// Go to the end screen (endScreen is a field)
    /// </summary>
    private void EndGame()
    {
        SceneManager.LoadScene(endScreen);
        Destroy(this.gameObject);
    }

    public void AddToFriendCounter(int NpcNumber)
    {
        FriendCounterUI.transform.GetChild(NpcNumber).gameObject.SetActive(true);
    }

}
