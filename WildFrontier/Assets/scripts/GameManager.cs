// game manager script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] WolfAgentMovement agent;
    [SerializeField] PlayerController playerController;
    //[SerializeField] WolfDirection wolfController;
    [SerializeField] float minDistance;
    [SerializeField] float InstantiateOffset; 
    private NavMeshPath path;
    private Bounds worldBounds;
    private GameObject viewer;

    bool flag = false;

    private int numberOfEnemies = 4; // number of enemies to be instantiated at checkpoint

    // list of level checkpoints
    private List<Vector3> checkpoints = new List<Vector3>();

    // Helper vector to find a random position on the map
    Vector3 randomPosition;

    // list of enemies
    private GameObject[] enemies;

    // enemies to instantiate
    [SerializeField] GameObject ImpalerEnemy;
    [SerializeField] GameObject GrimEnemy;

    // variable to check if enemies are instantiated

    bool areEnemiesInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        worldBounds = groundTilemap.localBounds;
        viewer = GameObject.Find("viewer"); 
        Debug.Log("up is: " + Vector2.up);
        //Debug.Log("world bounds are: " + worldBounds);
        //Debug.Log("min : " + worldBounds.min);
        //Debug.Log("max : " + worldBounds.max);
        //Debug.Log(".................");
        //Debug.Log("min x is : " + worldBounds.min.x);
        //Debug.Log("max x is : " + worldBounds.max.x);
        //Debug.Log("min y is : " + worldBounds.min.y);
        //Debug.Log("max y is : " + worldBounds.max.y);
        //Debug.Log(worldBounds.center);
        generateCheckpoints();

    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        { // if valid checkpoints have been generated
            flag = false;
            agent.GetLevelCheckpoints(checkpoints);
        }

        if(areEnemiesInstantiated == true) // enemies instantiated
        {
            areEnemiesInstantiated = false;
            // store them in a gameobject array
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //checkEnemiesStatus = 
        }

        // Game over 
        //GameOver();
    }

    private void generateCheckpoints()
    {
        while(checkpoints.Count <= 3)
        {
            // quadrants
            generateRandomDestination();
            
        }
        flag = true;

        //Debug.Log("finished filling up checkpoints list");
        //for (int i = 0; i < checkpoints.Count; i++)
        //{
        //    Debug.Log($"Vector {i}: {checkpoints[i]}");
        //}
    }

    private void generateRandomDestination()
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
           // Debug.Log("Vector checkpoints count: " + checkpoints.Count);

            checkpoints.Add(randomDestination);
        } else
        {
            //Debug.Log("generating random...");
            generateRandomDestination();
            // Invoke("generateRandomDestination", 10);
        }
    }

    private bool IsBetweenAcceptableDistance(Vector3 destination)
    {
            for (int i = 0; i < checkpoints.Count; i++)
            {
                //Debug.Log($"Distance between point {i} and new position {destination} is:  {Vector3.Distance(checkpoints[i], destination)}");
                if (Vector3.Distance(checkpoints[i], destination) < minDistance)
                {
                    return false;
                }
            }
            return true;
    }

    public void InstantiateEnemies(Vector3 currentCheckpoint)
    {
        // Create a copy of the enemies

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(currentCheckpoint.x - InstantiateOffset, currentCheckpoint.x + InstantiateOffset), Random.Range(currentCheckpoint.y - InstantiateOffset, currentCheckpoint.y + InstantiateOffset), 0);

            if (i%2==0)
            {
                Instantiate(ImpalerEnemy, newPos, Quaternion.identity); // quaternion for rotation
            }
            else
            {
                Instantiate(GrimEnemy, newPos, Quaternion.identity); // quaternion for rotation
            }
        }

        areEnemiesInstantiated = true;



    }


    private void GameOver()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        if (playerController.health == 0 || agent.health == 0)
        {
            yield return new WaitForSeconds(2);
            // pause the game
            Time.timeScale = 0;
            // load game over screen
            Debug.Log("You have lost!!");
        }
    }
}
