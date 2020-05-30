using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    public WaspCounter waspCounter;

    [SerializeField] 
    private TextMeshProUGUI displayResultsText = null;
    [SerializeField]
    private TextMeshProUGUI ingameDefeatedWaspsText = null;
    [SerializeField] 
    private TextMeshProUGUI ingameTimerText = null;
    [SerializeField] 
    private TextMeshProUGUI resultTimeText = null;
    [SerializeField]
    private TextMeshProUGUI restartGameText = null;
    [SerializeField] 
    private TextMeshProUGUI toTitleText = null;
    [SerializeField]
    private TextMeshProUGUI highscoreText = null;

    //Initiates the language that was saved in the options menu
    void Start()
    {
    }

    // The results of the current attempt are displayed and the game then checks if the current number of defeated wasps
    // or the amount of time that the player survived is better than the saved highscore
    void Update()
    {
        waspCounter.SetNewWaspHighscore();
        SetLanguage(PlayerPrefs.GetString("LanguageSetting", "English"));
    }

    //This is accessed by pressing the main menu button in the gamer over menu to return to the main menu (which is scene 0)
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    //This is accessed by pressing the restart button in the game over menu to restart the game
    //To restart the game, the cursor has to be hidden and time as well as the audio start again
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    //This sets the current language for the game over menu depending on the setting in the options menu
    public void SetLanguage(string lang)
    {
        if (lang == "English")
        {
            restartGameText.text = "Retry";
            resultTimeText.text = "Result:";
            toTitleText.text = "Main Menu";
            displayResultsText.text = ingameDefeatedWaspsText.text + " Wasps";
            highscoreText.text = PlayerPrefs.GetFloat("WaspHighscore", 0).ToString() + " Wasps";
        }
        else if (lang == "German")
        {
            restartGameText.text = "Neustart";
            resultTimeText.text = "Ergebnis:";
            toTitleText.text = "Hauptmenü";
            displayResultsText.text = ingameDefeatedWaspsText.text + " Wespen";
            highscoreText.text = PlayerPrefs.GetFloat("WaspHighscore", 0).ToString() + " Wespen";
        }
    }

}
