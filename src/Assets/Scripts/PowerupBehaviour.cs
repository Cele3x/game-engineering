using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
 
    private AudioSource audioSource;
    

    private GameController gameController;
    private bool triggered = false;

    void Start()
    {

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontriggerenter");
        if (triggered == false)
        {
            
            if (other.gameObject.CompareTag("Player"))
            {
                triggered = true;
                //audioSource.Play(0);
               
                gameController.CollectSpray();
                Destroy(gameObject);
            }
            
        }
    }
    /* private void OnCollisionEnter(Collision collision)
 {
     Debug.Log("collision power up");
     if (triggered == false)
     {
         Debug.Log("" + collision.other);
         if (collision.other.CompareTag("Player"))
         {
             triggered = true;
             //audioSource.Play(0);
             //rend.enabled = false;

             gameController.CollectSpray();
         }

     }
 }*/
}
