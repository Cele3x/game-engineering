using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public Slider slider;

    private string langKey = "LanguageSetting";
    private string langDefault = "English";

    [SerializeField] public TextMeshProUGUI optionsText;
    [SerializeField] public TextMeshProUGUI quitText;
    [SerializeField] public TextMeshProUGUI optionsTitleText;
    [SerializeField] public TextMeshProUGUI volumeText;
    [SerializeField] public TextMeshProUGUI backText;
    [SerializeField] public TextMeshProUGUI languageText;
    [SerializeField] public TextMeshProUGUI languageButtonText;

    void Start()
    {
        Cursor.visible = true;
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    void Update()
    {
        if (PlayerPrefs.GetString(langKey, langDefault) == "German")
        {
            changeMainMenuLanguageToGerman();
        }
        else if (PlayerPrefs.GetString(langKey, langDefault) == "English")
        {
            changeMainMenuLanguageToEnglish();
        }
    }

    public void PlayGame() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Switches the language on the press of the switch language button
    public void switchLanguage()
    {

        if (PlayerPrefs.GetString(langKey, langDefault) == "English")
        {
            PlayerPrefs.SetString(langKey, "German");
            changeMainMenuLanguageToGerman();
        }
        else if (PlayerPrefs.GetString(langKey, langDefault) == "German")
        {
            PlayerPrefs.SetString(langKey, "English");
            changeMainMenuLanguageToEnglish();
        }
    }

    public void changeMainMenuLanguageToGerman()
    {
        //setLanguage as preference
        optionsText.text = "Optionen";
        quitText.text = "Beenden";
        optionsTitleText.text = "Optionen";
        volumeText.text = "Lautstärke";
        backText.text = "Zurück";
        languageText.text = "Sprache Wechseln";
        languageButtonText.text = "Englisch";
    }

    public void changeMainMenuLanguageToEnglish()
    {
        //setLanguage as preference
        optionsText.text = "Options";
        quitText.text = "Quit";
        optionsTitleText.text = "Options";
        volumeText.text = "Volume";
        backText.text = "Back";
        languageText.text = "Switch Language";
        languageButtonText.text = "German";
    }


}
