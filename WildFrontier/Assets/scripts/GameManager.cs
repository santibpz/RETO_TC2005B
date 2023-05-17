using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] WolfAgentMovement agent;
    [SerializeField] float minDistance;
    private NavMeshPath path;
    private Bounds worldBounds;
    private Bounds quadrantBounds;
    private GameObject viewer;

    bool flag = false;

    // list of checkpoints
    private List<Vector3> checkpoints = new List<Vector3>();

    Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        worldBounds = groundTilemap.localBounds;
        
        viewer = GameObject.Find("viewer");
        Debug.Log("world bounds are: " + worldBounds);
        Debug.Log("min x is : " + worldBounds.min.x);
        Debug.Log("max x is : " + worldBounds.max.x);
        Debug.Log("min y is : " + worldBounds.min.y);
        Debug.Log("max y is : " + worldBounds.max.y);
        //Debug.Log(worldBounds.center);
        //generateCheckpoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        { // if valid checkpoints have been generated
            flag = false;
            agent.GetLevelCheckpoints(checkpoints);
        }
    }

    private void generateCheckpoints()
    {
        while(checkpoints.Count <= 3)
        {
            generateRandomDestination();
            
        }
        flag = true;

        Debug.Log("finished filling up checkpoints list");
        for (int i = 0; i < checkpoints.Count; i++)
        {
            Debug.Log($"Vector {i}: {checkpoints[i]}");
        }
    }

    private void generateRandomDestination() // PASS it BOUNDSSS
    {
        float xPos = Random.Range(worldBounds.min.x, worldBounds.max.x);
        float yPos = Random.Range(worldBounds.min.y, worldBounds.max.y);
        randomPosition = new Vector3(xPos, yPos, 0);
        viewer.transform.position = randomPosition;
        checkValidDestination(randomPosition);
        
    }

    private void checkValidDestination(Vector3 randomDestination)
    {
        if ((agent.wolfAgent.CalculatePath(randomDestination, path) && path.status == NavMeshPathStatus.PathComplete) && IsBetweenAcceptableDistance(randomDestination))
        {
            //if the destination position can be reached
            Debug.Log("Vector checkpoints count: " + checkpoints.Count);

            checkpoints.Add(randomDestination);
        } else
        {
            Debug.Log("generating random...");
            generateRandomDestination();
            // Invoke("generateRandomDestination", 10);
        }
    }

    private bool IsBetweenAcceptableDistance(Vector3 destination)
    {
            for (int i = 0; i < checkpoints.Count; i++)
            {
                Debug.Log($"Distance between point {i} and new position {destination} is:  {Vector3.Distance(checkpoints[i], destination)}");
                if (Vector3.Distance(checkpoints[i], destination) < minDistance)
                {
                    return false;
                }
            }
            return true;

    }

}
