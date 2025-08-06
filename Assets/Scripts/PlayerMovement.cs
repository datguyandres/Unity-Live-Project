using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Range(1.0f, 10f)]
    public float VerticalSpeed = 1.0f;

    [Range(0.5f, 10f)]
    public float HorizontalSpeed = 1.0f;

    Rigidbody2D rb2D;

    public float speed = 1f;

    public Vector3 StartingPoint = new Vector3(-10.673912f, -12.402813f, -8.44999981f);

    public GameObject WalkingPopUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Awake()
    {
        this.transform.position = GameManager.Instance.PlayerLastLocation;
        
    }*/

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        this.transform.position = GameManager.Instance.PlayerLastLocation;
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceFromStart = Vector3.Distance(this.transform.position, StartingPoint);
        if (DistanceFromStart > 10f)
        {
            WalkingPopUp.SetActive(false);
            Debug.Log("true");
            
        }
        if (GameManager.Instance.PlayerCanMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            rb2D.linearVelocity = movement * speed;

        }
        else
        {
            rb2D.linearVelocity = new Vector2(0,0);
        }

        
    }
}
