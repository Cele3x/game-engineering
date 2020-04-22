﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private Lang pauseLang;


    [SerializeField] public TextMeshProUGUI resumeText;
    [SerializeField] public TextMeshProUGUI toTitleText;

    void Start()
    {
        pauseLang = new Lang(PlayerPrefs.GetString("LanguageSetting"));

        resumeText.text = pauseLang.GetEntry("pause_resume");
        toTitleText.text = pauseLang.GetEntry("pause_gameover_title");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
           if(GameIsPaused) 
           {
               Resume();
           } else
            {
               Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = true;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

}
