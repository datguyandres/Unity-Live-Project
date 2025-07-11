using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //var camera = Camera; // set this via inspector// using this should work
    public float shake  = 0.0f;
    float shakeAmount = 0.7f;
    float decreaseFactor = 1.0f;

    void Update() {
        if (shake > 0) {
            Vector3 shakeunit = Random.insideUnitSphere * shakeAmount;
            this.transform.localPosition = new Vector3(shakeunit.x, shakeunit.y, -20);
            shake -= Time.deltaTime * decreaseFactor;

        } else {
            shake = 0.0f;
        }
    }

}
