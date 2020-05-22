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


    private bool spawnBeeRoutineActive = false;

    private int _currentSpawnIndex = 0;

    //sets the maximum of bees to be alive at the same time
    [SerializeField]
    private int maximumBeesActive;
    
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

    }

    /*
     * If the number of living bees has reached the maximum nothing happens.
     * Spawns a bee at the position defined by the _currentSpawnIndex otherwise.
     */
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
    //creates a new powerup that can be collected by the user   
    private void InstantiatePowerUp(GameObject powerUp, Vector3[] spawnPoints )
    {
        Instantiate(powerUp, spawnPoints[Random.Range(0, spawnPoints.Length)], Quaternion.Euler(0, 0, 0));
    }

    /*
     * Informs the PlayerController, that the Player is taking damage
     * Checks the Players amount of health and calls game over when it's 0
     */
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

    /*
    * Informs the UI and the livingBeeCounter that the players has defeated a bee.
    * Spawns a bee, when the bee defeated was the last one alive.
    */
    public void PlayerScores()
    {
        //playerScore += 1;
        _waspCounter.IncreaseWaspCounter();
        livingBeeCounter--;
        if (livingBeeCounter <= 0) { InstantiateBee(); }
        
    }

    /*
    * Informs the PlayerController that a Spray PowerUp has been picked up.
    * Plays the corresponding sound and restarts the SpawnSpray routine .
    */
    public void CollectSpray()
    {
        playerController.CollectSpray();
        audioSource.PlayOneShot(powerUpCollectSound, 1);
        StartCoroutine(SpawnSpray());

    }

    /*
   * Informs the PlayerController that a Health PowerUp has been picked up.
   * Plays the corresponding sound and restarts the SpawnHealth routine .
   */
    public void CollectHealth()
    {
        playerController.Heal(1);
        audioSource.PlayOneShot(powerUpCollectSound, 1);
        StartCoroutine(SpawnHealth());

    }

    IEnumerator SpawnHealth()
    {
        yield return new WaitForSeconds(Random.Range(powerUpRandomSpanMin, powerUpRandomSpanMax));
        InstantiatePowerUp(powerUpHealth, onionSpawnPoints);
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
        InstantiatePowerUp(powerUpSpray, spraySpawnPoints);
    }

   /*
    * Activates the Game Over Screen,
    * pauses the game ( or at least all frame rate independent functions)
    * and activates the mouse cursor
    */
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
