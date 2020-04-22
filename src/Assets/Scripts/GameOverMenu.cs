using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    public GameObject gameOverMenuUI;

    private Lang gameOverLang;

    [SerializeField] public TextMeshProUGUI displayTimerText;
    [SerializeField] public TextMeshProUGUI ingameTimerText;
    [SerializeField] public TextMeshProUGUI resultTimeText;
    [SerializeField] public TextMeshProUGUI toTitleText;


    // Start is called before the first frame update
    void Start()
    {
        setLanguage(PlayerPrefs.GetString("LanguageSetting"));
    }

    // Update is called once per frame
    void Update()
    {
            displayTimerText.text = ingameTimerText.text;   
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
