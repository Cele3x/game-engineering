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
    private string controlKey = "ControlSetting";
    private string langDefault = "English";

    [SerializeField] 
    private TextMeshProUGUI optionsText = null;
    [SerializeField] 
    private TextMeshProUGUI quitText = null;
    [SerializeField] 
    private TextMeshProUGUI optionsTitleText = null;
    [SerializeField] 
    private TextMeshProUGUI volumeText = null;
    [SerializeField] 
    private TextMeshProUGUI backText = null;
    [SerializeField] 
    private TextMeshProUGUI languageText = null;
    [SerializeField] 
    private TextMeshProUGUI languageButtonText = null;
    [SerializeField] 
    private TextMeshProUGUI controlsText = null;
    [SerializeField] 
    private TextMeshProUGUI controlsButtonText = null;

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
        controlsText.text = "Umgekehrte Maussteuerung";
        controlsButtonText.text = "Sprühen/Angreifen";
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
        controlsText.text = "Reverse Mouse Controls";
        controlsButtonText.text = "Spray/Attack";
    }

    public void changeMouseControls()
    {
        if (PlayerPrefs.GetString(controlKey, "defaultControls") == "defaultControls")
        {
            PlayerPrefs.SetString(controlKey, "altControls");
        }
        else if (PlayerPrefs.GetString(controlKey, "defaultControls") == "altControls")
        {
            PlayerPrefs.SetString(controlKey, "defaultControls");
        }
    }


}
