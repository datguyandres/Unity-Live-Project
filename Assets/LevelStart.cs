using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject ImageHolder;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.Instance.PlayerScore = 0;
        animator = ImageHolder.GetComponent<Animator>();
        if (animator != null)
        {
            Debug.Log("should play animation here");
            bool OpenBounce = animator.GetBool("DoBounceIN");

            //animator.SetBool("DoBounceIN", true);
            //animator.SetBool("DoBounceIN", false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
