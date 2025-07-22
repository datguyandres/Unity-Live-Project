using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject Player;

    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField]
    public float minDistance = 0.1f;
    [SerializeField,Range(0.1f, 2f)]
    private float width;



    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;
        line.startWidth = line.endWidth = width;
    }
    void Update() //making points for our line renderer
    {

        //if (Input.GetMouseButton(0))
       // {
            Vector3 currentPosition = Player.transform.position;
            currentPosition.z = 0f;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                if (previousPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, currentPosition);
                previousPosition = currentPosition;
            }
        //}
        
    }
}
