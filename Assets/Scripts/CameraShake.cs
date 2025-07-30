using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //var camera = Camera; // set this via inspector// using this should work
    public float shake  = 0.0f;
    float shakeAmount = 2.0f;
    float decreaseFactor = 1.0f;

    public Vector3 StartingPosition;

    void Start()
    {
        StartingPosition = this.transform.localPosition;
        Debug.Log("Starting Position is: " + StartingPosition);
    }

    void Update() {
        if (shake > 0) {
            Vector3 shakeunit = Random.insideUnitSphere * shakeAmount;
            this.transform.localPosition = new Vector3(StartingPosition.x + shakeunit.x, StartingPosition.y + shakeunit.y, 0);
            shake -= Time.deltaTime * decreaseFactor;

        } else {
            shake = 0.0f;
            this.transform.localPosition = StartingPosition;
        }
    }

}
