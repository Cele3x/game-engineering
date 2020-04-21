using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBarController : MonoBehaviour
{
    private PlayerController playerController;
    private Lang livesLang;


    [SerializeField] private TextMeshProUGUI hudLives;


    // Start is called before the first frame update
    void Start()
    {
        livesLang = new Lang(PlayerPrefs.GetString("LanguageSetting"));

        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        playerController.onHealthChangedCallback += UpdateLivesHUD;
        UpdateLivesHUD();
    }

    private void UpdateLivesHUD() { hudLives.text = playerController.Health + " " + livesLang.GetEntry("ingame_lives"); }
}
