using UnityEngine;

public class MaelleFacialExpressions : MonoBehaviour
{

    public GameObject CurrentMaelle;

    public bool BadScoreBool;
    public bool GoodScoreBool;
    public bool OkayScoreBool;

    GameObject PriorExpression;

    Transform GetCurrentChild;
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
        Transform GetCurrentChild = transform.GetChild(1);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        BadScoreBool = false;

    }


    void GoodScore()
    {
        Transform GetCurrentChild = transform.GetChild(0);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        GoodScoreBool = false;

    }

    void OkayScore()
    {
        Transform GetCurrentChild = transform.GetChild(2);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        OkayScoreBool = false;
    }

    public void ObstacleHit()
    {
        GameObject PriorExpression = GetCurrentChild.gameObject;
        GetCurrentChild = transform.GetChild(1);
        CurrentMaelle.SetActive(false);
        CurrentMaelle = GetCurrentChild.gameObject;
        CurrentMaelle.SetActive(true);
        BadScoreBool = false;


    }
}
