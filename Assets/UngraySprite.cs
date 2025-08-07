using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI; 

public class UngraySprite : MonoBehaviour
{
    public int NPCNum;
    public UnityEngine.UI.Image image; 

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
       
            if (GameManager.Instance.NpcsBeaten.Contains(NPCNum) == true)
            {
                image.color = new Color(255, 255, 255, 255);
            }
        }
    
}
