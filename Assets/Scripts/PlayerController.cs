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

    public GameObject NpcOnScreen;
    public GameObject Amica;

    public GameObject Level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NpcOnScreen = Level.transform.GetChild(2).gameObject;
        Amica = Level.transform.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.Instance.Paused)
        {
            transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        transform.Translate(new Vector3(0,Input.GetAxis("Vertical"),0) * VerticalSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("TOPDOWNTEST");

        }


    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CheckPoint")
        {
            CheckpointHandler.GetComponent<CheckPointSetup>().OnCheckpointHit();
            LevelHandler.GetComponent<InLevelManager>().ExpressionScore += 10;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().CheckScoreUpdate();
            //GameManager.Instance.PlayerScore += 10;
        }

        else if (other.gameObject.tag == "Obstacle")
        {

            //considering this mechanic if we want the game to be harder - rafa
            //LevelHandler.GetComponent<InLevelManager>().checkpointsHit -= 1;
            Debug.Log("collided with phone");
            //NpcOnScreen.GetComponent<CameraShake>().shake = 1;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().ObstacleHit();
            Amica.GetComponent<Amica_Facial_Expressions>().ObstacleHit();
             LevelHandler.GetComponent<InLevelManager>().ExpressionScore -= 10;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().CheckScoreUpdate();
            this.GetComponent<AudioSource>().Play();
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
