using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject playerBody;
    public GameObject beePrefab;
    private GameObject parent;
    private PlayerController playerController;
    private int beeCounter = 0;
    public int playerScore = 0;
    public int beeScore = 0;
    
    private readonly Vector3[] _spawnPoints = new [] { new Vector3(-10, 0, 0), new Vector3(-10, 0, -40), 
                                                       new Vector3(10, 0, -20), new Vector3(-30, 0, -20)};

    private int _currentSpawnIndex = 0;
    
    void Start()
    {
        playerController = playerBody.GetComponentInParent<PlayerController>();
        parent = GameObject.FindWithTag("DynamicGameObjects");
        InstantiateBee();
    }

    private void InstantiateBee()
    {
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++  % _spawnPoints.Length], Quaternion.identity, parent.transform);
        bee.GetComponent<BeeController>().target = playerBody.transform;
        bee.name = "Bee_" + beeCounter++;
    }

    public void BeeScores()
    {
        beeScore += 1;
        playerController.TakeDamage(1f);

        Debug.Log("Autsch");

        if (playerController.Health <= 0)
        {
           GameOver();
        }
       
        InstantiateBee();
    }

    public void PlayerScores()
    {
        playerScore += 1;
        InstantiateBee();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        //TODO show Game Over Screen GameOverUI.SetActive(true);

    }
}
