using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBarController : MonoBehaviour
{
    public TextMeshProUGUI hudLives;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        playerController.onHealthChangedCallback += UpdateLivesHUD;
        UpdateLivesHUD();
    }

    private void UpdateLivesHUD() { hudLives.text = playerController.Health + " Lives"; }
}
