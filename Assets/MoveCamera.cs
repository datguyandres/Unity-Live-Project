using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject MainCamera;

    public float speed = 1;

    public Vector3 TargetPos;

    public Vector3 StartingPos;

    private bool InRoom = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartingPos = MainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (InRoom == true)
        {
            transform.position = Vector3.MoveTowards(MainCamera.transform.position, TargetPos, speed * Time.deltaTime);
        }
        else if (InRoom == false)
        {
            transform.position = Vector3.MoveTowards(MainCamera.transform.position, StartingPos, speed * Time.deltaTime);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) // player walks into a classroom
    {
        if (other.gameObject.tag == "npcChecker")
        {
            Debug.Log("MusicTransitionShuoldTriggerr");
            if (GameManager.Instance.InHallway)//walkoing INTO a classroom
            {
                Debug.Log("VERY IMPORTANT CHECK");
            }
            else //walking out of a classroom
            {
                
            }
        }
    }
}
