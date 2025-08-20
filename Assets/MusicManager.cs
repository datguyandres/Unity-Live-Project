using UnityEngine;
using System.Collections.Generic;
public class MusicManager : MonoBehaviour
{
    public AudioSource HallwayTheme;
    public AudioSource Classroom1Theme;
    public AudioSource Classroom2Theme;
    public AudioSource HallwayAmbience;
    public AudioSource ScienceRoomAmbience;
    public AudioSource EnglishRoomAmbience;


    public AudioSource CurrentMusic;
    public AudioSource CurrentAmbience;

    public float fadeDuration = 2f;

    private int CurrentSongID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentSongID = AudioManager.instance.MusicID;
        SwitchMusic(CurrentSongID);

    }

    // Update is called once per frame

    public void SwitchMusic(int NewSongID)
    {
        if (CurrentMusic != null)
        {
            CurrentMusic.Stop();
            CurrentAmbience.Stop();
        }
        switch (NewSongID) //would prefer to do an array of sounds
        {
            case 0:
                HallwayTheme.Play();
                HallwayAmbience.Play();
                CurrentMusic = HallwayTheme;
                CurrentAmbience = HallwayAmbience;
                break;
            case 1:
                Classroom1Theme.Play();
                ScienceRoomAmbience.Play();
                CurrentMusic = Classroom1Theme;
                CurrentAmbience = ScienceRoomAmbience;
                break;
            case 2:
                Classroom2Theme.Play();
                EnglishRoomAmbience.Play();
                CurrentMusic = Classroom2Theme;
                CurrentAmbience = EnglishRoomAmbience;
                break;

        }
    }
    

}
