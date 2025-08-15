using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

public class NpcTrigger : DialogueTriggeringObject
{

    public bool IsHighlighted;

    public int NpcNumber; // ASSIGN THIS ON EDITOR SO EACH NPC IS A DIFFERENT NUMBER, start with 0 please
    public Material mat;

    public int LevelNum; //each npc will have a designated scene/level that they will lead to 


    public GameObject player;

    public bool WasBeaten;

    public GameObject InteractPopUP;

    public GameObject BackupGoalPopup;

    protected override void Start()
    {
        mat = GetComponent<Renderer>().material;
        base.Start();
    }


    /// <summary>
    /// if dialogue hasn't started and player is in range of an NPC, start some dialogue
    /// else continue existing dialogue
    /// 
    /// run when the interact button is pressed
    /// </summary>
    public override void StartOrAdvanceDialogue()
    {
        if (IsHighlighted && !GameManager.Instance.InLevel)
        {
            StartDialogue();
        }
        else 
        {
            base.StartOrAdvanceDialogue();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            player = other.gameObject;
            GameManager.Instance.CurrentDialogueObject = this;
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
                StartDialogue();
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

            
        }
    }


    /// <summary>
    /// Sets up dialogue with this NPC
    /// </summary>
    protected override void StartDialogue()
    {

        //if (HasCompletedMyLevel  false) // some sort of trigger that prevents the player from replaying on the same npc
        // {
        GameManager.Instance.PlayerCanMove = false;
        IsHighlighted = false;
        index = 0;
        
        if(GameManager.Instance.PlayerWon)
        {
            currentDialogue = Get1dArrayFrom2D(GameManager.Instance.NpcWinLines, NpcNumber);
        } else if (GameManager.Instance.InLevel)
        {
            currentDialogue = Get1dArrayFrom2D(GameManager.Instance.NpcLoseLines, NpcNumber);
        } else
        {
            currentDialogue = Get1dArrayFrom2D(GameManager.Instance.NpcLines, NpcNumber);
        }

        textComponent.gameObject.SetActive(true);
        NextLine();
        InDialogue = true;
        
        BackupGoalPopup.SetActive(false);
        DialogueBox.SetActive(true);
        TalkingCharacterImage.SetActive(true);
        //Debug.Log(GameManager.Instance.NpcLines[NpcNumber, 0]); //showing how to access the lines


        // }


        //SceneManager.LoadScene("Testing_Environment");

        //SceneManager.LoadScene(sceneANumber); what we will use once our scenes have 
        // been indexed properly and have multiple scenes
        //scene switching code/function call would go here?
    }

    protected override IEnumerator TypeLine()
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
            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }
            
        }
    }

    protected override void EndDialogue()
    {

        base.EndDialogue();

        //start level or end 

        GameManager.Instance.StartOrEndLevel(NpcNumber, player);
    }
    
    /// <summary>
    /// helper method that gets a row of a 2d array
    /// </summary>
    /// <param name="TwoDArray">the array referenced</param>
    /// <param name="row">the row of the array</param>
    /// <returns>a 1d array of strings with a row of the 2d array</returns>
    private string[] Get1dArrayFrom2D(string[,] TwoDArray, int row)
    {
        string[] returned = new string[TwoDArray.GetLength(1)];
        for (int i = 0; i < TwoDArray.GetLength(1); i++)
        {
            returned[i] = TwoDArray[row, i];
        }
        return returned;
    }


}
