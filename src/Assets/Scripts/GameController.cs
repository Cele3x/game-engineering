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
    public GameObject powerUpSpray;
    public GameObject powerUpHealth;
    public AudioClip powerUpCollectSound;

    private GameObject parent;
    private PlayerController playerController;
    private WaspCounter _waspCounter;
    private AudioSource audioSource;
    private CsvLogger _logger;

    private int beeCounter = 0;
    private int livingBeeCounter = 0;

    //sets the interval of time in which the powerup spawns
    [SerializeField]
    private float powerUpRandomSpanMin;
    [SerializeField]
    private float powerUpRandomSpanMax;

    //sets the interval of time in which the bees spawn
    [SerializeField]
    private float spawnBeeRandomSpanMin;
    [SerializeField]
    private float spawnBeeRandomSpanMax;
 
    private readonly Vector3[] _spawnPoints = new [] { new Vector3(-10, 0, 0), new Vector3(-10, 0, -40), 
                                                       new Vector3(10, 0, -20), new Vector3(-30, 0, -20)};

    private readonly Vector3[] spraySpawnPoints = new[] { new Vector3(-23, 0.5f, -11), new Vector3(2, 0.5f, -30), new Vector3(-3, 0.5f, -37),
                                                       new Vector3(-31, 0.5f, -32), new Vector3(-39, 0.5f, -8), new Vector3(-44, 8.5f, -3)};
    private readonly Vector3[] onionSpawnPoints = new[] { new Vector3(-20, 0.5f, -33), new Vector3(-16, 0.5f, 5), new Vector3(-19, 0, -17), new Vector3(-30, 8.8f, -33) };

    //sprivate bool powerUpRoutineActive = false;
    //private bool powerUpInstanceActive = false;

    private bool spawnBeeRoutineActive = false;

    private int _currentSpawnIndex = 0;

    private readonly int maximumBeesActive = 15;
    
    void Start()
    {
        _logger = GetComponent<CsvLogger>();
        playerController = playerBody.GetComponentInParent<PlayerController>();
        _waspCounter = waspCounterController.GetComponent<WaspCounter>();
        parent = GameObject.FindWithTag("DynamicGameObjects");
        audioSource = GetComponent<AudioSource>();
        InstantiateBee();
        StartCoroutine(SpawnBeeRoutine());
        StartCoroutine(SpawnSpray());
        StartCoroutine(SpawnHealth());
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
        beeCounter++;
        GameObject bee = Instantiate(beePrefab, _spawnPoints[_currentSpawnIndex++  % _spawnPoints.Length], Quaternion.identity, parent.transform);
        bee.GetComponent<BeeController>().target = playerBody.transform;
        bee.GetComponent<BeeController>().beeId = beeCounter;
        bee.name = "Bee_" + beeCounter;
        livingBeeCounter++;
    }

    private void InstantiateSprayPowerUp()
    {
        Instantiate(powerUpSpray, spraySpawnPoints[Random.Range(0, spraySpawnPoints.Length)], Quaternion.Euler(0, 0, 0));
    }

    private void InstantiateHealthPowerUp()
    {
        Instantiate(powerUpHealth, onionSpawnPoints[Random.Range(0, onionSpawnPoints.Length)], Quaternion.Euler(0, 0, 0));
    }


    public void BeeScores()
    {

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
        StartCoroutine(SpawnSpray()); // powerUpInstanceActive = false;

    }

    public void CollectHealth()
    {
        playerController.Heal(1);
        audioSource.PlayOneShot(powerUpCollectSound, 1);
        StartCoroutine(SpawnHealth());

    }

    IEnumerator SpawnHealth()
    {
        yield return new WaitForSeconds(Random.Range(powerUpRandomSpanMin, powerUpRandomSpanMax));

        //create a new spray powerup that can be collected by the user        
        InstantiateHealthPowerUp();

        //powerUpInstanceActive = true;
        //powerUpRoutineActive = false;
    }

    IEnumerator SpawnBeeRoutine()
    {
        yield return new WaitForSeconds(Random.Range(spawnBeeRandomSpanMin, spawnBeeRandomSpanMax));

        InstantiateBee();
        spawnBeeRoutineActive = false;
    }


    IEnumerator SpawnSpray()
    {
        yield return new WaitForSeconds(Random.Range(powerUpRandomSpanMin, powerUpRandomSpanMax));

        //create a new spray powerup that can be collected by the user        
        InstantiateSprayPowerUp();

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
        _logger.SaveToFile();
    }

}
