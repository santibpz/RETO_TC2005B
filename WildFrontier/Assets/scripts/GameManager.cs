// game manager script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

[System.Serializable]
public class CheckpointDeath
{
    public int checkpoint;
    public int player_id;
    public int player_lose_count = 1;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] WolfAgentMovement agent;
    [SerializeField] PlayerController playerController;
    //[SerializeField] WolfDirection wolfController;
    [SerializeField] float minDistance;
    [SerializeField] float InstantiateOffset;
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject UIcanvas;
    [SerializeField] CheckReceivedData checker;
    [SerializeField] InsertCheckpointDeath insertCheckpointDeath;
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

    bool areEnemiesInstantiated = false;

    // check status of enemies
    bool checkStatusOfEnemies = false;

    // check if player has reached final level
    bool playerHasReachedFinalLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        worldBounds = groundTilemap.localBounds;
        viewer = GameObject.Find("viewer");
        Debug.Log("up is: " + Vector2.up);

        // check if player has items
        StartCoroutine(FetchPlayerData());

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

        if (areEnemiesInstantiated == true) // enemies instantiated
        {
            areEnemiesInstantiated = false;
            // store them in a gameobject array
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            checkStatusOfEnemies = true;
        }

        if (checkStatusOfEnemies == true)
        {
            CheckIfEnemiesDestroyed();
        } 

        // Game over 
        GameOver();
    }

    private void generateCheckpoints()
    {
        while (checkpoints.Count <= 3)
        {
            // generate reachable destinations for the wolf
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

    // check if there is a min distance between checkpoints
    private bool IsBetweenAcceptableDistance(Vector3 destination)
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (Vector3.Distance(checkpoints[i], destination) < minDistance)
            {
                return false;
            }
        }
        return true;
    }

    public void InstantiateEnemies(Vector3 currentCheckpoint, bool isFinalCheckPoint)
    {
        // Create a copy of the enemies

        if (isFinalCheckPoint == true)
        {
            playerHasReachedFinalLevel = true;
            for (int i = 0; i < numberOfEnemies * 2; i++)
            {
                Vector3 newPos = new Vector3(Random.Range(currentCheckpoint.x - InstantiateOffset, currentCheckpoint.x + InstantiateOffset), Random.Range(currentCheckpoint.y - InstantiateOffset, currentCheckpoint.y + InstantiateOffset), 0);
                if(i == 0)
                {
                    // Final Boss is instantiated
                    Debug.Log("Final boss is instantiated");
                    // Instantiate(FinalBossEnemy, newPos, Quaternion.identity);
                }
                else
                {
                    if (i % 2 == 0)
                    {

                        Instantiate(ImpalerEnemy, newPos, Quaternion.identity); // quaternion for rotation
                    }
                    else
                    {
                        Instantiate(GrimEnemy, newPos, Quaternion.identity); // quaternion for rotation
                    }
                }
                
            }
        } else
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector3 newPos = new Vector3(Random.Range(currentCheckpoint.x - InstantiateOffset, currentCheckpoint.x + InstantiateOffset), Random.Range(currentCheckpoint.y - InstantiateOffset, currentCheckpoint.y + InstantiateOffset), 0);

                if (i % 2 == 0)
                {

                    Instantiate(ImpalerEnemy, newPos, Quaternion.identity); // quaternion for rotation
                }
                else
                {
                    Instantiate(GrimEnemy, newPos, Quaternion.identity); // quaternion for rotation
                }
            }
        }

        areEnemiesInstantiated = true;

    }

    private void CheckIfEnemiesDestroyed()
    {
        Debug.Log("checking");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null) return;
        }
        // if the for is completed, then all enemies have been killed
        checkStatusOfEnemies = false;
        if (playerHasReachedFinalLevel == true)
        {

            // Display winning screen
            // LevelCompleted()
            Debug.Log("CONGRATULATIONS YOU HAVE WON!");
        } else
        {
            // wolf is able to move
            agent.freeToMove = true;
        }
       
    }

    public void ControlCameraFollow(bool followPlayer)
    {
        if(followPlayer == true)
        {
            cameraController.cam.m_Follow = GameObject.FindGameObjectWithTag("Player").transform;
        } else
        {
            cameraController.cam.m_Follow = null;
        }
    }

    IEnumerator FetchPlayerData()
    {
        yield return new WaitForSeconds(1);
        checker.FetchItems();
        checker.FetchWeapons();
    }


    private void GameOver()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        if (playerController.health <= 0 || agent.health <= 0)
        {

            yield return new WaitForSeconds(2);
            // pause the game
            Time.timeScale = 0;

            // Hide game UI
            UIcanvas.SetActive(false);

            // load game over screen
            Debug.Log("You have lost!!");
            GameOverCanvas.SetActive(true);

            // register the checkpoint where the player lost
            CheckpointDeath checkpointDeath = new CheckpointDeath();
            checkpointDeath.checkpoint = agent.checkpointNo;
            checkpointDeath.player_id = PlayerPrefs.GetInt("player_id");

            string jsonData = JsonUtility.ToJson(checkpointDeath);
            insertCheckpointDeath.QueryInsertCheckpointDeath(jsonData);
        }
    }
}
