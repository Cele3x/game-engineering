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


    private Vector3 direction = Vector3.up;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
 

    void Update()
    {
        gameObject.transform.Translate(direction * Time.smoothDeltaTime*speed);

        if (gameObject.transform.position.y > up)
        {
            direction = Vector3.down;
        }
        else if (gameObject.transform.position.y < down)
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

                gameController.CollectSpray();
                Destroy(gameObject);
            }
            
        }
    }

}
