using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [Range(1.0f, 3.0f)]
    public int DistanceRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Yvalue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Yvalue =  this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, Yvalue + Mathf.PingPong(Time.time, DistanceRange), this.transform.position.z);
        
    }
}
