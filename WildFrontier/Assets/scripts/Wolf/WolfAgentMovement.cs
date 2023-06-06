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
    bool isWolfStopped = true;
    private List<Vector3> levelCheckpoints;
    

    // Start is called before the first frame update
    void Start()
    {
        wolfAgent = GetComponent<NavMeshAgent>();
        wolfAgent.updateRotation = false;
        wolfAgent.updateUpAxis = false;
        viewer = GameObject.Find("viewer");

        wolfAgent.isStopped = isWolfStopped; // initially the wolf is stopped
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCheckpoints.Count != 0)
        {
            MovementController(); // wolf movement controler
            toggleWolfMovement();// check if player stops wolf movement
        }
       // wolfAgent.SetDestination(viewer.transform.position);
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
                //wolfGraphic.isMoving = true;
                checkpointNo++;
            }
            
        }
    }

    private void toggleWolfMovement()
    {
        if(Input.GetKeyDown("h")) // pressing 'h' to stop the wolf movement
        {
            isWolfStopped = !isWolfStopped;
            wolfGraphic.isMoving = !isWolfStopped;
            
            wolfAgent.isStopped = isWolfStopped;
            
            Debug.Log("status: " + wolfAgent.isStopped);
        }
    }


}

