// wolf agent movement script
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WolfAgentMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public NavMeshAgent wolfAgent;
    private GameObject viewer;
    public WolfDirection wolfGraphic;
    private int checkpointNo = 0;
    private bool hasReachedLastCheckpoint = false;

    bool isWolfStopped = true; // check if the player stops the wolf

    private List<Vector3> levelCheckpoints; // list of checkpoint that are received by the game manager

    public int health = 100; // wolf health

    bool flag; // helper flag to control Wolf controller function

    bool isOnCheckpointRoute; // check if wolf is en route

    public bool freeToMove = false; // check if wolf can continue to the next checkpoint


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

        // flags to allow wolf control 
        if (wolfAgent.hasPath && isOnCheckpointRoute)
        {
            isOnCheckpointRoute = false;
            flag = true;
            
        }

        // control the wolf movement at checkpoint
        MovementController();

        // check if player stops wolf movement
        toggleWolfMovement();
 
        // check if wolf health is 0
        if(health == 0)
        {
            wolfGraphic.isWolfDead = true;
        }

        // check if player has killed all enemies
        if(freeToMove && hasReachedLastCheckpoint == false)
        {
            freeToMove = false;
            Debug.Log("player has killed all enemies");
            SetWolfDestination();
        }
    }

    public void GetLevelCheckpoints(List<Vector3>checkpoints)
    {
            Debug.Log("receiving checkpoints");
            levelCheckpoints = checkpoints;
            SetWolfDestination();
    }

    private void MovementController()
    {
        if (wolfAgent.hasPath == false && flag == true) // wolf has reached checkpoint
        {

            if(hasReachedLastCheckpoint)
            {
                // final battle
                Debug.Log("Final checkpoint of the game");
            }

            flag = false;
            Debug.Log("wolf has no path");

            // set the wolf movement at checkpoint
            wolfGraphic.isMoving = false;

            // instantiate enemies
            gameManager.InstantiateEnemies(wolfAgent.transform.position, hasReachedLastCheckpoint);
        }
    }

    void SetWolfDestination()
    {
        if (checkpointNo == levelCheckpoints.Count - 1) // check if player has reached last checkpoint
        {
            hasReachedLastCheckpoint = true;
        }
        Debug.Log("Setting wolf dest");
        viewer.transform.position = levelCheckpoints[checkpointNo];
        wolfAgent.SetDestination(levelCheckpoints[checkpointNo]); 
        wolfAgent.isStopped = true;
        wolfGraphic.isMoving = false;
        isOnCheckpointRoute = true;
        checkpointNo++; 
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

