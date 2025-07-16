using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    [Range(1.0f, 3.0f)]
    public int DistanceRange;
    public float Xvalue;

    [Range(0.1f, 2.0f)]
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Xvalue =  this.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float SecondsForLoop = DistanceRange / speed;
        ///this.transform.position = new Vector3(Mathf.PingPong(Time.time, Xvalue + DistanceRange), this.transform.position.y, this.transform.position.z);
        this.transform.position = new Vector3(Xvalue + Mathf.PingPong(Time.time * SecondsForLoop, DistanceRange), this.transform.position.y, this.transform.position.z);
        
    }
}
