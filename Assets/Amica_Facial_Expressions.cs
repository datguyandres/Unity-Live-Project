using UnityEngine;

public class Amica_Facial_Expressions : MonoBehaviour
{
    public GameObject CurrentAmica;

    public bool Distracted;

    public bool Lockedin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform GetCurrentChild = transform.GetChild(1);
        CurrentAmica = GetCurrentChild.gameObject;
        CurrentAmica.SetActive(true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Distracted)
        {
            DistractedExpression();
        }
        else if (Lockedin)
        {
            LockedInExpression();
        }

    }


    void DistractedExpression()
    {
        Transform GetCurrentChild = transform.GetChild(0);
        CurrentAmica.SetActive(false);
        CurrentAmica = GetCurrentChild.gameObject;
        CurrentAmica.SetActive(true);
        Distracted = false;

    }

    void LockedInExpression()
    {
        Transform GetCurrentChild = transform.GetChild(1);
        CurrentAmica.SetActive(false);
        CurrentAmica = GetCurrentChild.gameObject;
        CurrentAmica.SetActive(true);
        Lockedin = false;

    }
}
