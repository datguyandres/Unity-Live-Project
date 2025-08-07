using UnityEngine;

public class WaveGamePopUp : MonoBehaviour
{

    public GameObject Player;
    public GameObject GamePopUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceFromStart = Vector3.Distance(this.transform.position, Player.transform.position);
        Debug.Log("distance from starting point" + DistanceFromStart);
        if(DistanceFromStart > 10 )
        {
            GamePopUp.SetActive(false);
        }

    }
}
