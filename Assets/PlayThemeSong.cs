using UnityEngine;

public class PlayThemeSong : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
    }

}
