using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    private GameController gameController;
    private bool triggered = false;
    private float speed = 0.5f;
    private float up = 1;
    private float down = 0.5F;
    private float initialY;


    private Vector3 direction = Vector3.up;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        initialY = gameObject.transform.position.y;
    }
 

    void Update()
    {
        gameObject.transform.Translate(direction * Time.smoothDeltaTime*speed);

        if (gameObject.transform.position.y > up+ initialY)
        {
            direction = Vector3.down;
        }
        else if (gameObject.transform.position.y < down+ initialY)
        {
            direction = Vector3.up;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontriggerenter");
        if (triggered == false)
        {
            
            if (other.gameObject.CompareTag("Player"))
            {
                triggered = true;
                ActivatePowerUp();
                Destroy(gameObject);
            }
            
        }
    }

    private void ActivatePowerUp()
    {
        if(this.gameObject.CompareTag("SprayPowerUp"))
        {
            gameController.CollectSpray();
        }
        else if (this.gameObject.CompareTag("HealthPowerUp"))
        {
            gameController.CollectHealth();
        }

    }

}
