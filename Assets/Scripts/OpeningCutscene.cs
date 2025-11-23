using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private Animator CutsceneAnimation;

    [SerializeField] private DialogueTriggeringObject StartDialogue;

    private bool startDialoguePlayed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(CutsceneAnimation == null)
        {
            Debug.LogWarning("No cutscene animation was found by the start dialogue trigger");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.CurrentDialogueObject == StartDialogue)
        {
            startDialoguePlayed = true;
        }

        if(GameManager.Instance.PlayerCanMove && startDialoguePlayed)
        {
            CutsceneAnimation.SetBool("StartDialoguePlayed", true);
        }
    }

    public void EndAnimation()
    {
        CutsceneAnimation.StopPlayback();
        CutsceneAnimation.enabled = false;
        GameManager.Instance.PlayerCanMove = true;
    }
}
