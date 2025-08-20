using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int CheckpointNum = 0;
    [Range(1.0f, 10f)]
    public float VerticalSpeed = 1.0f;

    [Range(0.5f, 10f)]
    public float HorizontalSpeed = 1.0f;

    public GameObject CheckpointHandler;
    public GameObject Camera;

    public GameObject LevelHandler;

    private bool playerKnowsControls = false;

    public GameObject NpcOnScreen;
    public GameObject Amica;

    public GameObject Level;

    [SerializeField] private AudioClip HitPhoneSoundClip;
    [SerializeField] private AudioClip HitCheckPointSoundClip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (NpcOnScreen == null)
           NpcOnScreen = Level.transform.GetChild(2).gameObject;
        if(Amica == null)
            Amica = Level.transform.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.Instance.PlayerCanMove && playerKnowsControls)
        {
            transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (GameManager.Instance.PlayerCanMove)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Vertical"), 0) * VerticalSpeed * Time.deltaTime);
            //start the player moving fwd
            if(Input.GetAxis("Vertical") != 0)
            {
                playerKnowsControls = true;
            }
        }

#if DEBUG
        //this SHOULD not work in build
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("TOPDOWNTEST");

        }
#endif


    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CheckPoint")
        {
            CheckpointHandler.GetComponent<CheckPointSetup>().OnCheckpointHit();
            LevelHandler.GetComponent<InLevelManager>().ExpressionScore += 10;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().CheckScoreUpdate();
            AudioManager.PlaySoundFXClip(HitCheckPointSoundClip, transform, 1f);
            //GameManager.Instance.PlayerScore += 10;
        }

        else if (other.gameObject.tag == "Obstacle")
        {

            //considering this mechanic if we want the game to be harder - rafa
            //LevelHandler.GetComponent<InLevelManager>().checkpointsHit -= 1;
            Debug.Log("collided with phone");
            //NpcOnScreen.GetComponent<CameraShake>().shake = 1;
            InLevelManager inLevelManager = LevelHandler.GetComponent<InLevelManager>();

            //testing these making you "miss a checkpoint" when hit.
            inLevelManager.checkpointsMissed++;

            NpcOnScreen.GetComponent<MaelleFacialExpressions>().ObstacleHit();
            Amica.GetComponent<Amica_Facial_Expressions>().ObstacleHit();
            inLevelManager.ExpressionScore -= 10;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().CheckScoreUpdate();
            AudioManager.PlaySoundFXClip(HitPhoneSoundClip, transform, 1f);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "FinishLine")
        {
            //GameManager.Instance.PlayerWon = true;
            //GameManager.Instance.DifficultyLevel++;
            LevelHandler.GetComponent<InLevelManager>().EndLevel();
        }
    }

}
