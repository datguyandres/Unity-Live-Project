using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [Range(1.0f, 3.0f)]
    public int DistanceRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject centerObject; // The object to orbit around
    public float radius = 2f;       // Radius of the circular path
    public float speed = 2f;        // Speed of rotation
    private float angle;            // Current angle in radians

    void FixedUpdate()
    {
        // Calculate the new angle based on time and speed
        angle += speed * Time.deltaTime;

        // Ensure the angle stays within 0-2*PI
        angle %= (2 * Mathf.PI);

        // Calculate the new position using sine and cosine
        float x = centerObject.transform.position.x + radius * Mathf.Cos(angle);
        float y = centerObject.transform.position.y + radius * Mathf.Sin(angle);
        float z = centerObject.transform.position.z; // Keep the same y-coordinate

        // Apply the new position
        transform.position = new Vector3(x, y, z);
    }
}
