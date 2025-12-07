using System;
using UnityEngine;

public class interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "npcChecker")//just reusing the npc checker to check if its within interact range of interactable
        {
            
        }
    }
    
}
