using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// 8/13/2025
/// Purpose: Hold methods and actions that all dialogue triggering objects can use
/// restrictions: relies heavily on the game manager
/// </summary>
public abstract class DialogueTriggeringObject : MonoBehaviour
{
    // Text display stuff
    public TextMeshProUGUI textComponent;
    public GameObject DialogueBox;
    public GameObject TalkingCharacterImage;

    public float textSpeed;
    
    public string CurrentText;
    protected int index;

    public static bool InDialogue;

    public string[] currentDialogue;

    protected virtual void Start()
    {
        //if we dont have the dialogue box, go find it
        if(textComponent == null)
            textComponent = GameObject.FindWithTag("DialogueBox").GetComponent<TextMeshProUGUI>();

        textComponent.text = string.Empty;
    }

    /// <summary>
    /// by default, just advances current dialogue
    /// </summary>
    public virtual void StartOrAdvanceDialogue()
    {
        if (InDialogue)
        {
            if (textComponent.text == CurrentText)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = CurrentText;
            }
        }
    }

    protected abstract void StartDialogue();

    /// <summary>
    /// Advance to the next line of dialogue
    /// </summary>
    protected virtual void NextLine()
    {
        if (!GameManager.Instance.Paused)
        {
            if (index <= currentDialogue.Length - 1)
            {
                CurrentText = currentDialogue[index];
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }
    }

    protected virtual void EndDialogue()
    {
        DialogueBox.SetActive(false);
        InDialogue = false;
        textComponent.text = string.Empty;
        GameManager.Instance.PlayerCanMove = true;
        GameManager.Instance.Paused = false;
        TalkingCharacterImage.SetActive(false);

        if (GameManager.Instance.CurrentDialogueObject == this)
            GameManager.Instance.CurrentDialogueObject = null;
        else
            Debug.LogWarning("Dialogue was playing from an object other than the GameManager's CurrentDialogueObject");
    }

    /// <summary>
    /// Type lines, one character at a time, at the set text speed
    /// </summary>
    /// <returns>The time until the next line is typed</returns>
    protected virtual IEnumerator TypeLine()
    {

        foreach (char c in CurrentText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }
}