using UnityEngine;

public class CheckpointStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //all checkpoints start deactivated because they get activated one at a time
    {
        Invoke("Disabler", 1.0f);
    }

    // Update is called once per frame
    void Disabler()
    {
        this.gameObject.SetActive(false);
    }

}
