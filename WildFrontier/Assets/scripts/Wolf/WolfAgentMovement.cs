// wolf agent movement script
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WolfAgentMovement : MonoBehaviour
{
    public NavMeshAgent wolfAgent;
    private GameObject viewer;
    public WolfDirection wolfGraphic;
    private int checkpointNo = 0;
    private bool hasReachedLastCheckpoint = false;
    bool isWolfStopped = false;
    private List<Vector3> levelCheckpoints;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        wolfAgent = GetComponent<NavMeshAgent>();
        wolfAgent.updateRotation = false;
        wolfAgent.updateUpAxis = false;
        viewer = GameObject.Find("viewer");

    }

    // Update is called once per frame
    void Update()
    {
        if (levelCheckpoints.Count != 0)
        {
            MovementController(); // wolf movement controler
            toggleWolfMovement();// check if player stops wolf movement
        }
        wolfAgent.SetDestination(viewer.transform.position);
    }

    public void GetLevelCheckpoints(List<Vector3>checkpoints)
    {
            Debug.Log("receiving checkpoints");
            levelCheckpoints = checkpoints;
    }

    private void MovementController()
    {
        if (!wolfAgent.hasPath && !hasReachedLastCheckpoint)
        {
            if(checkpointNo == levelCheckpoints.Count) // if wolf agent has reached last checkpoint
            {
                Debug.Log("No: " + checkpointNo);
                Debug.Log("count: " + levelCheckpoints.Count);
                wolfGraphic.isMoving = false;
                hasReachedLastCheckpoint = true;
            } else
            {
                viewer.transform.position = levelCheckpoints[checkpointNo];
                wolfAgent.SetDestination(levelCheckpoints[checkpointNo]); // set wolf destination to a checkpoint
                wolfGraphic.isMoving = true;
                checkpointNo++;
            }
            
        }
    }

    private void toggleWolfMovement()
    {
        if(Input.GetKeyDown("h"))
        {
            Debug.Log("V pressed");
            wolfGraphic.isMoving = isWolfStopped;
            isWolfStopped = !isWolfStopped;
            wolfAgent.isStopped = isWolfStopped;
            
            Debug.Log("status: " + wolfAgent.isStopped);
        }
    }


}

