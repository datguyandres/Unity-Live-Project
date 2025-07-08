using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class NpcTrigger : MonoBehaviour
{

    public bool IsHighlighted;

    public int NpcNumber; // ASSIGN THIS ON EDITOR SO EACH NPC IS A DIFFERENT NUMBER, start with 0 please
    public Material mat;

    public int LevelNum; //each npc will have a designated scene/level that they will lead to 

    public TextMeshProUGUI textComponent;

    public float textSpeed;

    private int index;

    public bool InDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsHighlighted)
        {
            NpcInteraction();
        }

        if (Input.GetMouseButtonDown(0) && InDialogue )
        {
            if (textComponent.text == GameManager.Instance.NpcLines[NpcNumber, index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = GameManager.Instance.NpcLines[NpcNumber, index];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")
        {
            Debug.Log("Interacted with the npcChecker");
            if (mat != null)
            {
                mat.EnableKeyword("_EMISSION");
                IsHighlighted = true;
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
                IsHighlighted = false;
            }
        }
    }


    void NpcInteraction()
    {

        //if (HasCompletedMyLevel  false) // some sort of trigger that prevents the player from replaying on the same npc
        // {
        Debug.Log("Activated event trigger");
        IsHighlighted = false;
        index = 0;
        textComponent.gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        InDialogue = true;
        Debug.Log(GameManager.Instance.NpcLines[NpcNumber, 0]); //showing how to access the lines


        // }


        //SceneManager.LoadScene("Testing_Environment");

        //SceneManager.LoadScene(sceneANumber); what we will use once our scenes have 
        // been indexed properly and have multiple scenes
        //scene switching code/function call would go here?
    }

    IEnumerator TypeLine()
    {
        foreach (char c in GameManager.Instance.NpcLines[NpcNumber, index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
        if (index < 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            InDialogue = false;
            textComponent.text = string.Empty;
            textComponent.gameObject.SetActive(false);

            SceneManager.LoadScene(GameManager.Instance.DifficultyLevel);
        }
    }
    



}
