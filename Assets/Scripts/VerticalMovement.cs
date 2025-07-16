using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [Range(1.0f, 3.0f)]
    public int DistanceRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Yvalue;

    [Range(0.1f, 2.0f)]
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Yvalue =  this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float SecondsForLoop = DistanceRange / speed;
        this.transform.position = new Vector3(this.transform.position.x, Yvalue + Mathf.PingPong(Time.time * SecondsForLoop, DistanceRange), this.transform.position.z);
        
    }
}
