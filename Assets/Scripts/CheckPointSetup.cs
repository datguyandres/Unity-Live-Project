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

    [SerializeField] public InLevelManager inLevelManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //List<GameObject> CheckPointList;
    void Start()
    {
        //get the in level manager
        inLevelManager = GameObject.FindGameObjectWithTag("InLevelManager").GetComponent<InLevelManager>();

        TotalChildren = transform.childCount;
        CheckPointArray = new GameObject[transform.childCount];// create empty array size of childrens
        //populate w/ all children
        //(may include non-checkpoints if they are children!)
        for (int i = 0; i < transform.childCount; i++)
        {
            CheckPointArray[i] = transform.GetChild(i).gameObject;
        }
        System.Array.Sort(CheckPointArray,
                   (a, b) => { return a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()); });
        System.Array.Reverse(CheckPointArray); //sorting our array of checkpoints


        LiveCheckpoint = 0;
        CurrentCP = CheckPointArray[LiveCheckpoint].gameObject;// grab current checkpoint
        Invoke("SetCheckPointActive", 1.2f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Player != null && CurrentCP != null)
        {
            float distance = DistanceBetweenPlayerAndCheckpoint(); //distance of point from player
           // Debug.Log("Distance between " + CheckPointArray[LiveCheckpoint + 1].name + " and " + Player.name + ": " + distance);

            //if player half the distance to the next point delete the current one and spawn the next one without awarding points
            float DistBtwnPnts = DistanceBetweenCheckPoints();
            //Debug.Log("Distance between " + CurrentCP.name + " and " + CheckPointArray[LiveCheckpoint + 1].name + ": " + DistBtwnPnts);

            if (distance < DistBtwnPnts/2)
            {
                //inLevelManager.LevelScore -= 1;
                SetNextCheckpoint();
                //Debug.Log("works here");
            }
        }


    }


    private void SetCheckPointActive()//turn on a specific checkpoint
    {

        if (LiveCheckpoint + 1 < TotalChildren)
        {
            CheckPointArray[LiveCheckpoint].gameObject.SetActive(true);
            CurrentCP = CheckPointArray[LiveCheckpoint].gameObject;
        }
    }

    private void SetNextCheckpoint()
    {
        if (LiveCheckpoint < CheckPointArray.Length)
        {
            CheckPointArray[LiveCheckpoint].gameObject.SetActive(false);//deactivate hit checkpoint
            LiveCheckpoint++;
            SetCheckPointActive();
        }
    }

    /// <summary>
    /// boosts score and sets up next checkpoint
    /// </summary>
    public void OnCheckpointHit() 
    {
        inLevelManager.checkpointsHit += 1;
        Debug.Log("checkpoints hit: " + inLevelManager.checkpointsHit);
        SetNextCheckpoint();
    }

    /// <summary>
    /// distance between the current and next checkpoint (on the x-axis)
    /// </summary>
    /// <returns>the difference between the two x values, or -1 if </returns>
    public float DistanceBetweenCheckPoints()
    {
        if ((LiveCheckpoint + 1) < TotalChildren)
        {
            float dist = CheckPointArray[LiveCheckpoint + 1].transform.position.x - CurrentCP.transform.position.x;
            //Debug.Log("Distance checkpoint and next checkpoint: "+ dist);

            if (dist < 0)
            {
                Debug.LogError("next checkpoint has a lower x value than current checkpoint!");
            }

            return dist;
        }
        else
        {
            return -1;
        }
    }

    public float DistanceBetweenPlayerAndCheckpoint()
    {
        if ((LiveCheckpoint + 1) < TotalChildren)
        {
            float dist = CheckPointArray[LiveCheckpoint + 1].transform.position.x -  Player.transform.position.x;


            //Debug.Log("Distance between player and next checkpoint: "+ dist);
            return dist;
        }
        else
        {
            return -1;
        }
    }
}
