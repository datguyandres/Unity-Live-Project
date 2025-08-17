using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public GameObject MusicManager;

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
            Debug.Log("MusicTransitionShuoldTriggerr");
            if (GameManager.Instance.InHallway)//walkoing INTO a classroom
            {
                Debug.Log("VERY IMPORTANT CHECK");
                AudioManager.instance.MusicID = SongID;
                MusicManager.GetComponent<MusicManager>().SwitchMusic(SongID);
                GameManager.Instance.InHallway = false;
            }
            else //walking out of a classroom
            {
                AudioManager.instance.MusicID = 0;
                MusicManager.GetComponent<MusicManager>().SwitchMusic(0);
                GameManager.Instance.InHallway = true;
            }
        }
    }
}
