using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    [Range(1.0f, 3.0f)]
    public int DistanceRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(Mathf.PingPong(Time.time, DistanceRange), this.transform.position.y, this.transform.position.z);
        
    }
}
