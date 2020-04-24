﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    public GameObject gameOverMenuUI;
    public Timer timer;

    [SerializeField] 
    private TextMeshProUGUI displayTimerText = null;
    [SerializeField] 
    private TextMeshProUGUI ingameTimerText = null;
    [SerializeField] 
    private TextMeshProUGUI resultTimeText = null;
    [SerializeField] 
    private TextMeshProUGUI toTitleText = null;
    [SerializeField]
    private TextMeshProUGUI highscoreTimerText = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        displayTimerText.text = ingameTimerText.text;
        timer.setNewHighscore();
        highscoreTimerText.text = PlayerPrefs.GetFloat("Highscore", 0).ToString("F");
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
        gameOverMenuUI.SetActive(false);
    }

    public void setLanguage(string lang)
    {
        if (lang == "English")
        {
            resultTimeText.text = "Time";
            toTitleText.text = "Title";
        }
        else if (lang == "German")
        {
            resultTimeText.text = "Zeit";
            toTitleText.text = "Titel";
        }
    }

}
