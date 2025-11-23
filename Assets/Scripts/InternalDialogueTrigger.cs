using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class InternalDialogueTrigger : DialogueTriggeringObject
{
    public int DialogueID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        
        if (GameManager.Instance.SelfDialougeDone.IndexOf(DialogueID) > -1)
        {
            Destroy(gameObject);
        }

        base.Start();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            Debug.Log("Interacted with the npcChecker");
            GameManager.Instance.CurrentDialogueObject = this;
            StartDialogue();
        }
    }

    protected override void StartDialogue()
    {
        index = 0;
        
        DialogueBox.SetActive(true);
        GameManager.Instance.PlayerCanMove = false;
        InDialogue = true;
        TalkingCharacterImage.SetActive(true);

        NextLine();

    }

    

    protected override void EndDialogue()
    {
        base.EndDialogue();

        GameManager.Instance.SelfDialougeDone.Add(DialogueID);
        Destroy(gameObject);
    }
}
