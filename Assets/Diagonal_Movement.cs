using UnityEngine;

public class Diagonal_Movement : MonoBehaviour
{
    [Range(1.0f, 3.0f)]

    public int DistanceRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Xvalue;
    public float Yvalue;

    public bool InvertHorizontally = false;
    public bool InvertVertically = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Xvalue = this.transform.position.x;
        Yvalue =  this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!InvertHorizontally && !InvertVertically)
        {
            this.transform.position = new Vector3(Xvalue + Mathf.PingPong(Time.time, DistanceRange), Yvalue + Mathf.PingPong(Time.time, DistanceRange), this.transform.position.z);
        }
        else if (InvertHorizontally && !InvertVertically)
        {
            this.transform.position = new Vector3(Xvalue - Mathf.PingPong(Time.time, DistanceRange), Yvalue + Mathf.PingPong(Time.time, DistanceRange), this.transform.position.z);
        }
        else if (!InvertHorizontally && InvertVertically)
        {
            this.transform.position = new Vector3(Xvalue + Mathf.PingPong(Time.time, DistanceRange), Yvalue - Mathf.PingPong(Time.time, DistanceRange), this.transform.position.z);
        }
        else if (InvertHorizontally && InvertVertically)
        {
            this.transform.position = new Vector3(Xvalue - Mathf.PingPong(Time.time, DistanceRange), Yvalue - Mathf.PingPong(Time.time, DistanceRange), this.transform.position.z);
        }

    }
}
