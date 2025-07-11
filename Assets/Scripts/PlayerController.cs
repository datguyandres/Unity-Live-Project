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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
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
            GameManager.Instance.PlayerScore += 10;
        }

        else if (other.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.PlayerScore -= 10;
            Camera.GetComponent<CameraShake>().shake = 0.3f;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "FinishLine")
        {
            GameManager.Instance.PlayerWon = true;
            GameManager.Instance.DifficultyLevel++;
            SceneManager.LoadScene("TOPDOWNTEST");
        }
    }
}
