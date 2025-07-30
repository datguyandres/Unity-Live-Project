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

    public GameObject Level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NpcOnScreen = Level.transform.GetChild(2).gameObject;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime); //Player object shifting to the right
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * VerticalSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * VerticalSpeed * Time.deltaTime);
        }

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
            //GameManager.Instance.PlayerScore += 10;
        }

        else if (other.gameObject.tag == "Obstacle")
        {

            //considering this mechanic if we want the game to be harder - rafa
            //LevelHandler.GetComponent<InLevelManager>().checkpointsHit -= 1;
            Debug.Log("collided with phone");
            NpcOnScreen.GetComponent<CameraShake>().shake = 1;
            NpcOnScreen.GetComponent<MaelleFacialExpressions>().ObstacleHit();
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
