using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject beePrefab;
    public int playerScore = 0;
    public int beeScore = 0;
    
    void Start()
    {
        GameObject bee = Instantiate(beePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        bee.GetComponent<BeeController>().target = player.transform;
    }

    void Update()
    {
        
    }
}
