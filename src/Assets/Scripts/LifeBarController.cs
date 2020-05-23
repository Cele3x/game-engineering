using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBarController : MonoBehaviour
{
    private PlayerController playerController;
    private string langLives;

    [SerializeField] private TextMeshProUGUI hudLives = null;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        playerController.onHealthChangedCallback += UpdateLivesHUD;
        setLanguage(PlayerPrefs.GetString("LanguageSetting"));
        UpdateLivesHUD();
    }

    private void UpdateLivesHUD()
    {
        hudLives.text = playerController.Health + " " + langLives; 
    }

    private void setLanguage(string lang)
    {
        if (lang == "English")
        {
            langLives = "Lives";
        }
        else if (lang == "German") 
        { 
            langLives = "Leben"; 
        }
    }

}
