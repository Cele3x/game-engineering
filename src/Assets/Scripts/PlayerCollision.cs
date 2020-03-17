using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//not necessary at the moment, maybe needed for other collisions of the player

public class PlayerCollision : MonoBehaviour
{

    private GameController gameController;
    private GameObject player;
    private PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");


        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Player is null");
        }

        GameObject baseLevel = GameObject.FindGameObjectWithTag("GameController");
        if (baseLevel != null)
        {
            gameController = baseLevel.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
           



        }
    }

}
