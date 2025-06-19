using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject SineWaveHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space key was pressed");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("space key was pressed");
        }

    }
}
