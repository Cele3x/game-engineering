using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    [SerializeField] 
    private TextMeshProUGUI resumeText = null;
    [SerializeField] 
    private TextMeshProUGUI toTitleText = null;


    //Initiates the language that was saved in the options menu
    void Start()
    {
        SetLanguage(PlayerPrefs.GetString("LanguageSetting"));
    }

    // Check during the game if the player presses the Escape Key and open the menu or close it depending on if the pause menu is open or not
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

    //Resume the game after pausing, which means reactivating the HUD, the time, the audio and the player,
    //while displaying the pause menu and cursor
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

    //Pause the game while playing, which means deactivating the HUD, the cursor, the player and pausing the time as well as the audio, 
    //while disabling the pause menu and cursor
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

    //Loads the title screen/main menu (which is scene 0) after pressing a button in the pause menu 
    public void LoadTitleScreen()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    //This sets the current language for the pause menu depending on the setting in the options menu
    public void SetLanguage(string lang)
    {
        if (lang == "English")
        {
            resumeText.text = "Resume";
            toTitleText.text = "Main Menu";
        } 
        else if (lang == "German")
        {
            resumeText.text = "Fortsetzen";
            toTitleText.text = "Hauptmenü";
        }
    }

}
