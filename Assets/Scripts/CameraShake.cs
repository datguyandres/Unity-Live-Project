using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AnimationCurve curve;

    float t = 0f;
    void Update()
    {
        //...clever code
        float shake = Shake(10f, 2f, shakeCurve);
        //apply this shake to whatever you want, it's 1d right now but can be easily expanded to 2d
    }

    float Shake(float shakeDamper, float shakeTime, AnimationCurve curve)
    {
        t += Time.deltaTime;
        return Mathf.PerlinNoise(t / shakeDamper, 0f) * curve.Eval(t);
    }
    
    //NOT MY CODE FOR SHAKE I GOT IT ONLINE FROM UNITY FORUM 
}
