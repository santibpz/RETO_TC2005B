using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class WolfAgentMovement : MonoBehaviour
{
    public NavMeshAgent wolfAgent;
    private GameObject viewer;
    private int checkpointNo = 0;
    private bool hasReachedLastCheckpoint = false;
    private List<Vector3> levelCheckpoints;

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
       // MovementController();
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
                hasReachedLastCheckpoint = true;
            } else
            {
                viewer.transform.position = levelCheckpoints[checkpointNo];
                wolfAgent.SetDestination(levelCheckpoints[checkpointNo]);
                checkpointNo++;
            }
            
        }
    }

}

