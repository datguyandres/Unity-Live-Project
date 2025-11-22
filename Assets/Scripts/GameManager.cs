using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // This will carry data throughout our game and is callable throughtout every scene.

    public static GameManager Instance;

    public GameObject parent;

    /// <summary>
    /// The current level
    /// </summary>
    public int DifficultyLevel = 1;

    public bool Paused { get; set; } //set to public because if we are using this to stop the timer then i need to be able to access it when dialogue starts so timer stops

    public GameObject FriendCounterUI;

    public GameObject StartingPoint;


    //below variables aren't actually used in this script, im guessing they're here for convenience?

    public Vector3 PlayerLastLocation;

    public string playerLastScene;

    public List<int> NpcsBeaten = new List<int>();

    public bool InLevel = false; // will be used to check if a playey just left a level to trigger certain dialogue

    public bool PlayerCanMove = true;

    public bool PlayerWon = false;

    public List<int> SelfDialougeDone = new List<int>();

    [SerializeField] private string endScreen = "EndScreen";

    public bool InHallway = true;
    public GameObject genericNPCNotif; 


    public GameObject npcCounter;
    private int npcCount;

    // used to determine when player is going into a classroom and when they are leaving a classroom

    // public string[] Npc1;
    //public string[] Npc2;

    public string[,] NpcLines = new string[2, 4] {  //multi-dimensional array containing all npc lines
            {"Hey! I’m Maelle, what’s your name?", "Amica, that’s a nice name. Well, let’s get started on the poster then!", "Oh you didn’t get the instructions because you were late?", "Don’t worry, I can help you through it, it’ll be fun!"},
            {"My name? I’m Noah, just swapped into this class.", "Ideas about the group assignment? Well, it says to write about something you and your partner share in common.", "I do like watching basketball, how could you tell? Was it the logo on my hat?", "Yeah, it is kind of a giveaway. Well, let’s get started then."}
        };
    public string[,] PlayerLines = new string[3, 3] { //multi-dimensional array containing all player dialogue
            {"*sigh*, A week into school and I still haven’t gotten used to how loud it is.", "Though maybe it’d feel quieter if I had someone to walk with, a friend.", "Anyways, just gotta get to bio, should just be the green door to the right."},
            {"Gonna probably sit in the back and chill on my phone again aaaand the seats are taken.", "I guess I really shouldn’t have been late.", "Looks like the only open seat is up in the front too, unlucky."},
            {"Looks like there's only one open seat, in the back of the class.", "I do wonder who that blue guy is, sitting over there next to it.", "I didn’t see him in this class last week at all."}
        };

    public string[,] NpcWinLines = new string[2, 3] { //multi-dimensional array containing all player dialogue
            {"Ok, that’s correct, you can draw the last image for the poster.", "Wow, that looks great, you’re pretty good at drawing!", "I’ll go turn in the poster then, friend! \n[Befriended Maelle!]",},
            {"We sure did have a lot to write about.", "I just wish my favorite team made it to playoffs last year.", "Anyways, I’ll go turn in the paper, buddy. \n[Befriended Noah]"}
        };


    public string[,] NpcLoseLines = new string[2, 1] { //multi-dimensional array containing all player dialogue
            {"Oh, that one didn't work, maybe give it another try."},
            {"Uh, probably not that, let's try something else."}
        };

    public string[,] PostwinLines = new string[1, 1] { //multi-dimensional array containing all player dialogue
            {"I'd love to chat, but you're going to be late for your next class! Get going!"}
        };


    public DialogueTriggeringObject CurrentDialogueObject { get; set; }




    private void Awake()
    {
        Paused = false;
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
        else
        {
            Destroy(parent);
        }

        if (StartingPoint != null)
        {
            PlayerLastLocation = StartingPoint.transform.position;
            StartingPoint = null;
            Destroy(StartingPoint);
        }
        InHallway = true;

        //get the NPC count
        if(npcCounter != null)
        {
            npcCount = npcCounter.transform.childCount;
        } else if (SceneManager.GetActiveScene().name == "TOPDOWNTEST")
        {
            Debug.LogError("GameManager needs an NPC Counter but none was found!");
        }

        
    }

    /// <summary>
    /// runs the current NPC's dialogue
    /// </summary>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (CurrentDialogueObject != null)
            {
                CurrentDialogueObject.StartOrAdvanceDialogue();
            }

            else
            {
                genericNPCNotif.SetActive(true);
                StartCoroutine(HideGenericNPCNotif());
            }
        }
    }

    /// <summary>
    /// Go to the end screen (endScreen is a field)
    /// </summary>
    private void EndGame()
    {
        SceneManager.LoadScene(endScreen);
        DestroyPersistentObjects();
    }


    /// <summary>
    /// destroys gameManager, pause screen, and in-game UI
    /// </summary>
    public void DestroyPersistentObjects()
    {
        Destroy(parent);
    }


    public void AddToFriendCounter(int NpcNumber)
    {
        FriendCounterUI.transform.GetChild(NpcNumber).gameObject.SetActive(true);
    }

    /// <summary>
    /// starts or ends the current level
    /// </summary>
    public void StartOrEndLevel(int currentNPCNumber, GameObject player)
    {
        PlayerLastLocation = player.transform.position;
        playerLastScene = SceneManager.GetActiveScene().name;

        if (InLevel == false && NpcsBeaten.IndexOf(currentNPCNumber) == -1)
        {
            InLevel = true;
            //SceneManager.LoadScene(4);
            SceneManager.LoadScene(DifficultyLevel);
        }
        else
        {
            InLevel = false;
            PlayerWon = false;

            //if this is the last level, end the game

            if(NpcsBeaten.Count >= npcCount)
            {
                EndGame();
            } 
        }
    }

    /// <summary>
    /// shows the genericNPCNotif for a few seconds
    /// </summary>
    private IEnumerator HideGenericNPCNotif()
    {
        yield return new WaitForSeconds(5f);
        genericNPCNotif.SetActive(false);
    }

}
