using UnityEngine;

public class AmicaAnimator : MonoBehaviour
{
    public Animator AmicaController;
    //public Animator CutsceneAnimator; 

    public bool cutsceneMoveLeft;

    public bool cutsceneMoveUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AmicaController = GetComponent<Animator>();
        //CutsceneAnimator = GetComponent<Animator>();  
        cutsceneMoveLeft = false;
        cutsceneMoveUp = false;


    }

    // Update is called once per frame
    void FixedUpdate()
       
    {
        //going left
        // !!! SHOULD BE CHANGED WHEN BELLA'S THING IS IN !!!
        if (Input.GetAxis("Horizontal") < 0 && GameManager.Instance.PlayerCanMove)
        {
            Debug.Log("should be playing left animation");
            AmicaController.SetBool("goingLeft", true);
            
        }

        else
        {
            AmicaController.SetBool("goingLeft", false);
        }

        //going right
        if (Input.GetAxis("Horizontal") > 0 && GameManager.Instance.PlayerCanMove)
        {
            Debug.Log("should be playing right animation");
            AmicaController.SetBool("goingRight", true);
        }

        else
        {
            AmicaController.SetBool("goingRight", false);
        }

        //going up
        if ((Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0 && GameManager.Instance.PlayerCanMove) || (cutsceneMoveUp == true))
        {
            Debug.Log("should be playing back animation");
            AmicaController.SetBool("goingBack", true);
        }

        else
        {
            AmicaController.SetBool("goingBack", false);
        }

        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0 && GameManager.Instance.PlayerCanMove)
        {
            Debug.Log("should be playing forward animation");
            AmicaController.SetBool("goingForward", true);
        }

        else
        {
            AmicaController.SetBool("goingForward", false);
        }

        //CODE FOR NEW ANIMATION
         if (cutsceneMoveLeft == true) {
             AmicaController.SetBool("hasPhone", true);
         } else {
              AmicaController.SetBool("hasPhone", false);
         }
        
    }
}
