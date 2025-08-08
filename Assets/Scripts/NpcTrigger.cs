using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NpcTrigger : MonoBehaviour
{
    public InputSystem_Actions controls;

    [SerializeField] private string name;

    public string Name {get => name; private set => name = value;}

    public bool IsHighlighted;

    public int NpcNumber; // ASSIGN THIS ON EDITOR SO EACH NPC IS A DIFFERENT NUMBER, start with 0 please
    public Material mat;

    public int LevelNum; //each npc will have a designated scene/level that they will lead to 

    public TextMeshProUGUI textComponent;

    public GameObject DialogueBox;

    public float textSpeed;

    private int index;

    public bool InDialogue;

    public GameObject player;

    public bool WasBeaten;

    public string CurrentText;

    public GameObject InteractPopUP;

    /// <summary>
    /// the array to draw the current dialogue from
    /// </summary>
    private string[,] currentDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();

        mat = GetComponent<Renderer>().material;

        //if we dont have the dialogue box, go find it
        if(textComponent == null)
            textComponent = GameObject.FindWithTag("DialogueBox").GetComponent<TextMeshProUGUI>();

        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        //moved to an event in the PlayerInput component

        //if ( && IsHighlighted && !GameManager.Instance.InLevel)
        //{
        //    NpcInteraction();
        //}

        //if (controls.Player.Interact.WasPerformedThisFrame() && InDialogue)
        //{
        //    if (textComponent.text == CurrentText)
        //    {
        //        NextLine();
        //    }
        //    else
        //    {
        //        StopAllCoroutines();
        //        textComponent.text = CurrentText;
        //    }
        //}
    }


    /// <summary>
    /// called when space is pressed. do everything that happens when an NPC is interacted with
    /// </summary>
    public void Interact()
    {
        if (IsHighlighted && !GameManager.Instance.InLevel)
        {
            NpcInteraction();
        }

        if(InDialogue)
        {
            if(textComponent.text == CurrentText)
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComponent.text = CurrentText;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            player = other.gameObject;
            Debug.Log("Interacted with the npcChecker");
            if (mat != null)
            {
                mat.EnableKeyword("_EMISSION");
                InteractPopUP.SetActive(true);
                IsHighlighted = true;
            }

            if (GameManager.Instance.PlayerWon)
            {
                GameManager.Instance.NpcsBeaten.Add(NpcNumber);
                GameManager.Instance.AddToFriendCounter(NpcNumber);
            }

            if (GameManager.Instance.InLevel)
            {
                NpcInteraction();
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            if (mat != null)
            {
                mat.DisableKeyword("_EMISSION");
                InteractPopUP.SetActive(false);
                IsHighlighted = false;
            }

            GameManager.Instance.PlayerWon = false;
        }
    }


    private void NpcInteraction()
    {
        //if (HasCompletedMyLevel  false) // some sort of trigger that prevents the player from replaying on the same npc
        // {
        Debug.Log("Activated event trigger");
        GameManager.Instance.PlayerCanMove = false;
        IsHighlighted = false;
        index = 0;

        if (GameManager.Instance.PlayerWon)
        {
            currentDialogue = GameManager.Instance.NpcWinLines;
        }
        else if (!GameManager.Instance.InLevel)
        {
            currentDialogue = GameManager.Instance.NpcLines;
        }
        else
        {
            currentDialogue = GameManager.Instance.NpcLoseLines;
        }

        textComponent.gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        InDialogue = true;
        GameManager.Instance.Paused = true;
        DialogueBox.SetActive(true);
        //Debug.Log(GameManager.Instance.NpcLines[NpcNumber, 0]); //showing how to access the lines


        // }


        //SceneManager.LoadScene("Testing_Environment");

        //SceneManager.LoadScene(sceneANumber); what we will use once our scenes have 
        // been indexed properly and have multiple scenes
        //scene switching code/function call would go here?
    }

    IEnumerator TypeLine()
    {
        
        if (GameManager.Instance.NpcsBeaten.IndexOf(NpcNumber) > -1 && GameManager.Instance.InLevel != true)
        {
            CurrentText = "U ALREADY BEAT ME MANEEE";
            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }
        }


        else 
        {
            CurrentText = currentDialogue[NpcNumber, index];
            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }
            Debug.Log("testing dialogue after getting out of level");
            
        }
    }

    void NextLine()
    {
        if (index < GameManager.Instance.NpcLines.GetLength(1)-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            InDialogue = false;
            GameManager.Instance.Paused = false;
            DialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            //textComponent.gameObject.SetActive(false);
            GameManager.Instance.PlayerLastLocation = player.transform.position;
            GameManager.Instance.playerLastScene = SceneManager.GetActiveScene().name;
            GameManager.Instance.PlayerCanMove = true;
            if (GameManager.Instance.InLevel == false && GameManager.Instance.NpcsBeaten.IndexOf(NpcNumber) == -1)
            {
                GameManager.Instance.InLevel = true;
                //SceneManager.LoadScene(4);
                SceneManager.LoadScene(GameManager.Instance.DifficultyLevel);
            }
            else
            {
                GameManager.Instance.InLevel = false;
            }

        }
    }

    



}
