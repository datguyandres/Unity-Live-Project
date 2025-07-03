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
            Debug.Log("HIT");
            CheckpointHandler.GetComponent<CheckPointSetup>().OnCheckpointHit();
        }
    }
}
