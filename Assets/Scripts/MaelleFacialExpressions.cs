using UnityEngine;

public class MaelleFacialExpressions : MonoBehaviour

// i know the naming is not very helpful but this is works on any npc just add this file to their parent in the canvas
{

    public GameObject CurrentMaelle;

    public bool BadScoreBool;
    public bool GoodScoreBool;
    public bool OkayScoreBool;

    GameObject PriorExpression;

    Transform GetCurrentChild;

    [SerializeField] public InLevelManager inLevelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetCurrentChild = transform.GetChild(2);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);

    }


    void FixedUpdate()
    {

        if (BadScoreBool)
        {
            BadScore();
        }
        if (GoodScoreBool)
        {
            GoodScore();
        }
        if (OkayScoreBool)
        {
            OkayScore();
        }
        // if (GameManager.Instance.PlayerScore < 0)
        //{
        // }
    }

    //these methods just swap the current image with the new one and thats it

    void BadScore()
    {
        GetCurrentChild = transform.GetChild(1);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        BadScoreBool = false;

    }


    void GoodScore()
    {
        GetCurrentChild = transform.GetChild(0);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        GoodScoreBool = false;

    }

    void OkayScore()
    {
        GetCurrentChild = transform.GetChild(2);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        OkayScoreBool = false;
    }

    public void ObstacleHit()
    {
        PriorExpression = CurrentMaelle;
        GetCurrentChild = transform.GetChild(1);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        BadScoreBool = false;
        this.GetComponent<CameraShake>().shake = 1;
        Invoke("ResetAfterShake", 1f);


    }

    private void ResetAfterShake()
    {
        CurrentMaelle.SetActive(false);
        CurrentMaelle = PriorExpression;
        CurrentMaelle.SetActive(true);
    } 


    public void CheckScoreUpdate()//checks current score and updates expression if needed
    {
        if (inLevelManager.ExpressionScore <= -20)
        {
           BadScoreBool = true;
        }
        else if (inLevelManager.ExpressionScore >=40)
        {
            GoodScoreBool = true;
        }
        else if (inLevelManager.ExpressionScore >=10)
        {
            OkayScoreBool = true;
        }

    }
}
