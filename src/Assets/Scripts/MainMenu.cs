using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public Slider slider;
    private Lang mainMenuLang;

    [SerializeField] private TextMeshProUGUI optionsText;
    [SerializeField] private TextMeshProUGUI quitText;
    [SerializeField] private TextMeshProUGUI optionsTitleText;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private TextMeshProUGUI backText;
    [SerializeField] private TextMeshProUGUI languageText;
    [SerializeField] private TextMeshProUGUI languageButtonText;

    void Start()
    {
        Cursor.visible = true;
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        mainMenuLang = new Lang(PlayerPrefs.GetString("LanguageSetting", "English"));
    }

    void Update()
    {
        changeMainMenuLanguage();
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

    public void changeMainMenuLanguage() 
    { 
        //setLanguage as preference
        optionsText.text = mainMenuLang.GetEntry("main_options");
        quitText.text = mainMenuLang.GetEntry("main_quit");
        optionsTitleText.text = mainMenuLang.GetEntry("main_options");
        volumeText.text = mainMenuLang.GetEntry("options_volume");
        backText.text = mainMenuLang.GetEntry("options_back");
        languageText.text = mainMenuLang.GetEntry("options_language_text");
        languageButtonText.text = mainMenuLang.GetEntry("options_language_button");
    }

    public void switchLanguage()
    {

        if (PlayerPrefs.GetString("LanguageSetting") == "English")
        {
            PlayerPrefs.SetString("LanguageSetting", "German");
            mainMenuLang.SetLanguage(PlayerPrefs.GetString("LanguageSetting", "English"));

            Debug.Log(PlayerPrefs.GetString("LanguageSetting"));
        } else if (PlayerPrefs.GetString("LanguageSetting") == "German")
        {
            PlayerPrefs.SetString("LanguageSetting", "English");
            mainMenuLang.SetLanguage(PlayerPrefs.GetString("LanguageSetting", "English"));

            Debug.Log(PlayerPrefs.GetString("LanguageSetting"));
        }
    }


}
