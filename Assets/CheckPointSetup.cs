using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CheckPointSetup : MonoBehaviour
{

    public GameObject[] CheckPointArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //List<GameObject> CheckPointList;
    void Start()
    {
        CheckPointArray = new GameObject[transform.childCount];
        CheckPointArray = GameObject.FindGameObjectsWithTag("CheckPoint");
        System.Array.Sort(CheckPointArray,
                   (a, b) => { return a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()); });
        System.Array.Reverse(CheckPointArray);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
