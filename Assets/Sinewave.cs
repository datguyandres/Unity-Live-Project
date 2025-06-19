using UnityEngine;

public class Sinewave : MonoBehaviour
{

    public LineRenderer myLineRenderer;
    //passing LineRenderer Object from the unity ui in the script
    public int points;// determines the "resolution of our line"

    public float amplitude = 1;
    public float frequency = 1;

    public float MovementSpeed = 1; // setting this to 0 will stop the sin movement
    public Vector2 xLimits = new Vector2(9,1); //specify waves starting and ending points

    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        //initializing LineRenderer and assinging to a variable
    }

    void Draw()
    {
        float xStart = xLimits.x; //starting value in the x dimension
        float Tau = 2 * Mathf.PI; // in order to get a full cycle of y = sin(x), the x value needs to go from 0 to 2pi
        float xFinish = xLimits.y; //Tau; //ending value in the ny dimension

        myLineRenderer.positionCount = points;//creating as many positions in linerenderer as the variable points
        for (int currentPoint = 0; currentPoint < points; currentPoint++) //looping through all of these points to calculate and assign positions
        {
            //first we calculate x 
            float progress = (float)currentPoint / (points - 1); //finding current points progress in relation to the total number of positions as a value from 0 to 1
            float x = Mathf.Lerp(xStart, xFinish, progress); //lerp between starting and finishing values in this current progress
                                                             //lerp calculates the value of 2 floats at a given percentage 
            float y = amplitude*Mathf.Sin((Tau * frequency * x) +(Time.timeSinceLevelLoad* MovementSpeed)); // gives us number between -1 and 1, first and last value should be 0
            myLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0)); // assinging our x and y values into our line renderer before calling it in update


        }

    }

    void UpdateFrequency() //x axis stretch
    {

    }

    void UpdateAmplitude() // y axis stretch
    {

    }





    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            amplitude++;
            Debug.Log("S key was pressed");
        }

        if (Input.GetKey(KeyCode.W))
        {
            amplitude--;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            frequency--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            frequency++;
        }

        Draw(); // draw our line :)
        
    }
}
