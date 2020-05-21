using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject waspCounterController;
    public GameObject playerBody;
    public GameObject beePrefab;
    public GameObject powerUpPrefab;
    public AudioClip powerUpCollectSound;

    private GameObject parent;
    private PlayerController playerController;
    private WaspCounter _waspCounter;
    private AudioSource audioSource;

    private int beeCounter = 0;
    private int livingBeeCounter = 0;

    //sets the interval of time in which the powerup spawns
    private float powerUpRandomSpanMin = 30;
    private float powerUpRandomSpanMax = 35;

    //sets the interval of time in which the bees spawn
    private float spawnBeeRandomSpanMin = 25;
    private float spawnBeeRandomSpanMax = 40;

    public int playerScore = 0;
    public int beeScore = 0;
    
    private readonly Vector3[] _spawnPoints = new [] { new Vector3(-10, 0, 0), new Vector3(-10, 0, -40), 
                                                       new Vector3(10, 0, -20), new Vector3(-30, 0, -20)};

    private readonly Vector3[] powerupSpawnPoints = new[] { new Vector3(-4, 1, -4), new Vector3(2, 1, -30),};

    //sprivate bool powerUpRoutineActive = false;
    //private bool powerUpInstanceActive = false;

    private bool spawnBeeRoutineActive = false;

    private int _currentSpawnIndex = 0;

    private readonly int maximumBeesActive = 15;
    
    void Start()
    {
        playerController = playerBody.GetComponentInParent<PlayerController>();
        _waspCounter = waspCounterController.GetComponent<WaspCounter>();
        parent = GameObject.FindWithTag("DynamicGameObjects");
        audioSource = GetComponent<AudioSource>();
        InstantiateBee();
        StartCoroutine(SpawnBeeRoutine());
        StartCoroutine(SpawnPowerup());
    }
    void Update()
    {
       
        if (!spawnBeeRoutineActive)
        {
            spawnBeeRoutineActive = true;
            StartCoroutine(SpawnBeeRoutine());
        }

        /*
        //checks if powerup routine is active and if a powerup object already exists, if it doesn't, then activate the routine to spawn a new one
        if (!powerUpRoutineActive && !powerUpInstanceActive)
        {
            powerUpRoutineActive = true;
            StartCoroutine(SpawnPowerup());
        }
        */
    }

    private void InstantiateBee()
    {
        if (livingBeeCounter >= maximumBeesActive) return;
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++  % _spawnPoints.Length], Quaternion.identity, parent.transform);
        bee.GetComponent<BeeController>().target = playerBody.transform;
        bee.name = "Bee_" + beeCounter++;
        livingBeeCounter++;
       
    }

    private void InstantiatePowerUp(GameObject powerUp)
    {
        Instantiate(powerUp,powerupSpawnPoints[Random.Range(0, powerupSpawnPoints.Length)], Quaternion.Euler(0, 0, 0));
    }

    public void BeeScores()
    {
        beeScore += 1;
        livingBeeCounter--;
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
        //playerScore += 1;
        _waspCounter.IncreaseWaspCounter();
        livingBeeCounter--;
        if (livingBeeCounter <= 0) { InstantiateBee(); }
        
    }

    public void CollectSpray()
    {
        playerController.CollectSpray();
        audioSource.PlayOneShot(powerUpCollectSound, 1);
        StartCoroutine(SpawnPowerup()); // powerUpInstanceActive = false;

    }

    IEnumerator SpawnBeeRoutine()
    {
        yield return new WaitForSeconds(Random.Range(spawnBeeRandomSpanMin, spawnBeeRandomSpanMax));

        InstantiateBee();
        spawnBeeRoutineActive = false;
    }


    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(Random.Range(powerUpRandomSpanMin, powerUpRandomSpanMax));

        //create a new spray powerup that can be collected by the user        
        InstantiatePowerUp(powerUpPrefab);

        //powerUpInstanceActive = true;
        //powerUpRoutineActive = false;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
