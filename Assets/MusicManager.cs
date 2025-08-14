using UnityEngine;
using System.Collections.Generic; 
public class MusicManager : MonoBehaviour
{
    public AudioSource HallwayTheme;
    public AudioSource Classroom1Theme;
    public AudioSource Classroom2Theme;
    public AudioSource HallwayAmbience;


    public AudioSource CurrentMusic;

    public float fadeDuration = 2f;

    private int CurrentSongID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentSongID = AudioManager.instance.MusicID;
        /*switch (CurrentSongID) //would prefer to do an array of sounds
        {
            case 0:
                HallwayTheme.Play();
                HallwayAmbience.Play();
                CurrentMusic = HallwayTheme;
                break;
            case 1:
                Classroom1Theme.Play();
                CurrentMusic = Classroom1Theme;
                break;
            case 2:
                Classroom2Theme.Play();
                CurrentMusic = Classroom2Theme;
                break;

        }*/
        SwitchMusic(CurrentSongID);

    }

    // Update is called once per frame

    public void SwitchMusic(int NewSongID)
    {
        if (CurrentMusic != null)
        {
            CurrentMusic.Stop();
        }
        switch (NewSongID) //would prefer to do an array of sounds
        {
            case 0:
                HallwayTheme.Play();
                HallwayAmbience.Play();
                CurrentMusic = HallwayTheme;
                break;
            case 1:
                Classroom1Theme.Play();
                CurrentMusic = Classroom1Theme;
                break;
            case 2:
                Classroom2Theme.Play();
                CurrentMusic = Classroom2Theme;
                break;

        }
    }
}
