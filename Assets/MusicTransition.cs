using UnityEngine;

public class MusicTransition : MonoBehaviour
{

    public int SongID; // use this to determine which song this tile will trigger for the room the player is entering too from the hallway
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    void OnTriggerEnter2D(Collider2D other) // player walks into a classroom
    {
        if (other.gameObject.tag == "npcChecker")
        {
            Debug.Log("Interacted with the npcChecker");
            AudioManager.instance.MusicID = SongID;
        }
    }
}
