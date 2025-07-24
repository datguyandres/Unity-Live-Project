using UnityEngine;

public class MaelleFacialExpressions : MonoBehaviour
{

    public GameObject CurrentMaelle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (GameManager.Instance.PlayerScore < 0)
        {
            Transform GetCurrentChild = transform.GetChild(4);
            CurrentMaelle = GetCurrentChild.gameObject;
        }
    }

    void BadScore()
    {

    }

    void MehScore()
    {

    }

    void GoodScore()
    {

    }

    void TerribleScore()
    {
        
    }
}
