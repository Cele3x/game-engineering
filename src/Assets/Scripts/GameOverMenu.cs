using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    public Timer timer;
    public WaspCounter waspCounter;

    [SerializeField] 
    private TextMeshProUGUI displayTimerText = null;
    [SerializeField] 
    private TextMeshProUGUI ingameTimerText = null;
    [SerializeField] 
    private TextMeshProUGUI resultTimeText = null;
    [SerializeField]
    private TextMeshProUGUI restartGameText = null;
    [SerializeField] 
    private TextMeshProUGUI toTitleText = null;
    [SerializeField]
    private TextMeshProUGUI highscoreTimerText = null;


    // Start is called before the first frame update
    void Start()
    {
        SetLanguage(PlayerPrefs.GetString("LanguageSetting"));
    }

    // Update is called once per frame
    void Update()
    {
        displayTimerText.text = ingameTimerText.text;
        //waspCounter.SetNewWaspHighscore();
        timer.SetNewHighscore();
        highscoreTimerText.text = PlayerPrefs.GetFloat("Highscore", 0).ToString("F");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void SetLanguage(string lang)
    {
        if (lang == "English")
        {
            restartGameText.text = "Restart Game";
            resultTimeText.text = "Time";
            toTitleText.text = "Main Menu";
        }
        else if (lang == "German")
        {
            restartGameText.text = "Neustart";
            resultTimeText.text = "Zeit";
            toTitleText.text = "Hauptmenü";
        }
    }

}
