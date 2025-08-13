using UnityEngine;

public class Destroy_Event : MonoBehaviour
{

    [Header("Destroys attached obj")]
    [SerializeField] private int levelToDestroy;

    void Start()
    {
        if (GameManager.Instance.DifficultyLevel > 1)
        {
            Destroy(gameObject);
        }
    }
}
