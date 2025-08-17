using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public int MusicID; //will use this varible to determine which song should be used

    [SerializeField] private AudioSource SoundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        Debug.Log("Should be playing sound here ");

        /* AudioSource audioSource = Instantiate(SoundFXObject, spawnTransform.position, Quaternion.identity);

         audioSource.clip = audioClip;

         audioSource.Play();

         float clipLength = audioSource.clip.length;

         Destroy(audioSource.gameObject, clipLength);*/

        AudioSource.PlayClipAtPoint(audioClip, spawnTransform.position);

    }
}

