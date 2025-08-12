using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class InternalDialogueTrigger : MonoBehaviour
{
    private KeyCode interactKey = KeyCode.Space;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject DialogueBox;
    private int index;
    public string CurrentText;
    public bool InDialogue;
    public GameObject AmicaImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(interactKey) ) && InDialogue)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            Debug.Log("Interacted with the npcChecker");
            InternalDialogue();
        }
    }

    void InternalDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        DialogueBox.SetActive(true);
        GameManager.Instance.PlayerCanMove = false;
        InDialogue = true;
        AmicaImage.SetActive(true);

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            DialogueBox.SetActive(false);
            InDialogue = false;
            textComponent.text = string.Empty;
            GameManager.Instance.PlayerCanMove = true;
            AmicaImage.SetActive(false);
            Destroy(gameObject);
        }
    }
}
