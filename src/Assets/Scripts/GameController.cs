using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject playerBody;
    public GameObject beePrefab;
    public GameObject powerUpPrefab;
    private GameObject parent;
    private PlayerController playerController;
    private int beeCounter = 0;
    public int playerScore = 0;
    public int beeScore = 0;
    
    private readonly Vector3[] _spawnPoints = new [] { new Vector3(-10, 0, 0), new Vector3(-10, 0, -40), 
                                                       new Vector3(10, 0, -20), new Vector3(-30, 0, -20)};

    private readonly Vector3[] powerupSpawnPoints = new[] { new Vector3(-4, 1, -4), new Vector3(2, 1, -30),};
    private bool powerUpRoutineActive = false;

    private int _currentSpawnIndex = 0;
    
    void Start()
    {
        playerController = playerBody.GetComponentInParent<PlayerController>();
        parent = GameObject.FindWithTag("DynamicGameObjects");
        InstantiateBee();
        //instantiatePowerUp(powerUpPrefab);
    }
    void Update()
    {

        if (powerUpRoutineActive == false)
        {
            powerUpRoutineActive = true;
            StartCoroutine(SpawnPowerup());
        }

    }

    private void InstantiateBee()
    {
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++  % _spawnPoints.Length], Quaternion.identity, parent.transform);
        bee.GetComponent<BeeController>().target = playerBody.transform;
        bee.name = "Bee_" + beeCounter++;
    }
    private void InstantiatePowerUp(GameObject powerUp)
    {

        Instantiate(powerUp,powerupSpawnPoints[Random.Range(0, powerupSpawnPoints.Length)], Quaternion.Euler(0, 0, 0));
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

    public void CollectSpray()
    {
        playerController.CollectSpray();

    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(Random.Range(10,15));

       
        //if not game over:
        
        InstantiatePowerUp(powerUpPrefab);
        
        powerUpRoutineActive = false;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
