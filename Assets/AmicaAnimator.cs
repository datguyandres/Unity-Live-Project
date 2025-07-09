using UnityEngine;

public class AmicaAnimator : MonoBehaviour
{
    public Animator AmicaController; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AmicaController = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("should be playing left animation");
            AmicaController.SetBool("goingLeft", true);
        }

        else {
            AmicaController.SetBool("goingLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("should be playing right animation");
            AmicaController.SetBool("goingRight", true);
        }

        else
        {
            AmicaController.SetBool("goingRight", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("should be playing back animation");
            AmicaController.SetBool("goingBack", true);
        }

        else
        {
            AmicaController.SetBool("goingBack", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("should be playing forward animation");
            AmicaController.SetBool("goingForward", true);
        }

        else
        {
            AmicaController.SetBool("goingForward", false);
        }

    }
}
