using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatterGridController : MonoBehaviour
{

    public GameObject parentPlayer;
    private PlayerController playerController;

    public void Start()
    {
        playerController = parentPlayer.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.OnSwatterGridTrigger(other);
    }

}
