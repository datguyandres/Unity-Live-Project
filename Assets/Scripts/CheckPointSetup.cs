using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CheckPointSetup : MonoBehaviour
{

    public GameObject[] CheckPointArray;

    public int LiveCheckpoint;

    public GameObject Player;

    public GameObject CurrentCP;

    public int TotalChildren;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //List<GameObject> CheckPointList;
    void Start()
    {
        TotalChildren = transform.childCount;
        CheckPointArray = new GameObject[transform.childCount];// create empty array size of childrens
        CheckPointArray = GameObject.FindGameObjectsWithTag("CheckPoint");
        System.Array.Sort(CheckPointArray,
                   (a, b) => { return a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()); });
        System.Array.Reverse(CheckPointArray); //sorting our array of checkpoints

        LiveCheckpoint = 0;
        CurrentCP = CheckPointArray[LiveCheckpoint].gameObject;// grab current checkpoint
        Invoke("SetCheckPointActive", 1.2f);

    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null && CurrentCP != null)
        {
            float distance = Vector3.Distance(CurrentCP.transform.position, Player.transform.position); //distance of point from player
            Debug.Log("Distance between " + CurrentCP.name + " and " + Player.name + ": " + distance);
        }


    }

    void SetCheckPointActive()//turn on a specific checkpoint
    {

        if (LiveCheckpoint < TotalChildren)
        {
            CheckPointArray[LiveCheckpoint].gameObject.SetActive(true);
            CurrentCP = CheckPointArray[LiveCheckpoint].gameObject;
        }
    }

    public void OnCheckpointHit()
    {
        CheckPointArray[LiveCheckpoint].gameObject.SetActive(false);//deactivate hit checkpoint
        LiveCheckpoint++;
        SetCheckPointActive();
    }
}
