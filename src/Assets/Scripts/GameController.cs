using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   
    public GameObject playerBody;
    public GameObject beePrefab;
    private PlayerController playerController;
    public int playerScore = 0;
    public int beeScore = 0;
    
    private readonly Vector3[] _spawnPoints = new [] { new Vector3(-10, 0, 0), new Vector3(-10, 0, -40), 
                                                       new Vector3(10, 0, -20), new Vector3(-30, 0, -20)};

    private int _currentSpawnIndex = 0;
    
    void Start()
    {
        playerController = playerBody.GetComponentInParent<PlayerController>();
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++], Quaternion.identity);
        bee.GetComponent<BeeController>().target = playerBody.transform;
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
       
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++ % _spawnPoints.Length], Quaternion.identity);
        bee.GetComponent<BeeController>().target = playerBody.transform;
    }

    public void PlayerScores()
    {
        playerScore += 1;
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++ % _spawnPoints.Length], Quaternion.identity);
        bee.GetComponent<BeeController>().target = playerBody.transform;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        //TODO show Game Over Screen GameOverUI.SetActive(true);

    }
}
