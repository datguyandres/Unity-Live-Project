using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class NpcTrigger : MonoBehaviour
{

    private KeyCode interactKey = KeyCode.Space;

    [SerializeField] private string name;

    public string Name {get => name; private set => name = value;}

    public bool IsHighlighted;

    public int NpcNumber; // ASSIGN THIS ON EDITOR SO EACH NPC IS A DIFFERENT NUMBER, start with 0 please
    public Material mat;

    public int LevelNum; //each npc will have a designated scene/level that they will lead to 

    public TextMeshProUGUI textComponent;

    public float textSpeed;

    private int index;

    public bool InDialogue;

    public GameObject player;

    public bool WasBeaten;

    public string CurrentText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(interactKey) || Input.GetMouseButtonDown(0)) && IsHighlighted && !GameManager.Instance.InLevel)
        {
            NpcInteraction();
        }

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
            player = other.gameObject;
            Debug.Log("Interacted with the npcChecker");
            if (mat != null)
            {
                mat.EnableKeyword("_EMISSION");
                IsHighlighted = true;
            }

            if (GameManager.Instance.PlayerWon)
            {
                GameManager.Instance.NpcsBeaten.Add(NpcNumber);
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
                IsHighlighted = false;
            }

            GameManager.Instance.PlayerWon = false;
        }
    }


    void NpcInteraction()
    {

        //if (HasCompletedMyLevel  false) // some sort of trigger that prevents the player from replaying on the same npc
        // {
        Debug.Log("Activated event trigger");
        GameManager.Instance.PlayerCanMove = false;
        IsHighlighted = false;
        index = 0;
        textComponent.gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        InDialogue = true;
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


        else if (GameManager.Instance.PlayerWon)
        {
            CurrentText = GameManager.Instance.NpcWinLines[NpcNumber, index];
            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }
            Debug.Log("testing dialogue after getting out of level");
            
        }
        else if (GameManager.Instance.PlayerLost)
        {
            CurrentText = GameManager.Instance.NpcLoseLines[NpcNumber, index];
            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }

        }

        else if (GameManager.Instance.InLevel != true)
        {

            CurrentText = GameManager.Instance.NpcLines[NpcNumber, index];

            foreach (char c in CurrentText.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);

            }
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
            GameManager.Instance.PlayerLastLocation = player.transform.position;
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
