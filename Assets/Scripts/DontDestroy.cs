using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy Instance;

    private void Awake()
    {

        //NpcLines = new string[2, 2] {


        if (Instance != null) // makes sure we have only one instance of our main game manager
        {
            Destroy(gameObject);
            return; 
        }
        Instance = this; // makes it so that our class can be called anywhere without a reference
        DontDestroyOnLoad(gameObject); // prevents it from being destroyed on scene change


    }
}
