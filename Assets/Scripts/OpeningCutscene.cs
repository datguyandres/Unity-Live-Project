using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private Animator CutsceneAnimation;

    [SerializeField] private AmicaAnimator AmicaAnimator;

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
        if(!GameManager.Instance.OpeningCutscenePlayed)
        {
            GameManager.Instance.OpeningCutscenePlayed = true;
            CutsceneAnimation.enabled = true;
        }

        if(GameManager.Instance.CurrentDialogueObject == StartDialogue)
        {
            startDialoguePlayed = true;
        }

        if(GameManager.Instance.PlayerCanMove && startDialoguePlayed)
        {
            CutsceneAnimation.SetBool("StartDialoguePlayed", true);
        }
    }

    /// <summary>
    /// end the opening cutscene
    /// </summary>
    public void EndAnimation()
    {
        CutsceneAnimation.StopPlayback();
        CutsceneAnimation.enabled = false;
        AmicaAnimator.cutsceneMoveUp = false;
        GameManager.Instance.PlayerCanMove = true;
    }

    /// <summary>
    /// makes the animator move with the cutscene left
    /// </summary>
    public void StopMovingLeft()
    {
        AmicaAnimator.cutsceneMoveLeft = false;
        Debug.Log("Cutscene should be waiting!");
    }

    /// <summary>
    /// makes the animator move with the cutscene up
    /// </summary>
    public void StartMovingUp()
    {
        AmicaAnimator.cutsceneMoveUp = true;
    }

}
