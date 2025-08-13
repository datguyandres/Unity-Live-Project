using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource HallwayTheme;
    public AudioSource Classroom1Theme;
    public AudioSource Classroom2Theme;
    public AudioSource HallwayAmbience;

    public float fadeDuration = 2f;

    private int CurrentSongID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentSongID = AudioManager.instance.MusicID;
        switch (CurrentSongID)
        {
            case 0:
                HallwayTheme.Play();
                HallwayAmbience.Play();
                break;
            case 1:
                Classroom1Theme.Play();
                break;
            case 2:
                Classroom2Theme.Play();
                break;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
