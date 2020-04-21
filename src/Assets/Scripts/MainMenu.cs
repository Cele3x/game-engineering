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

    void Start()
    {
        Cursor.visible = true;
        changeMainMenuLanguage();
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
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
        mainMenuLang = new Lang("German");

        optionsText.text = mainMenuLang.GetEntry("main_options");
        quitText.text = mainMenuLang.GetEntry("main_quit");
        optionsTitleText.text = mainMenuLang.GetEntry("main_options");
        volumeText.text = mainMenuLang.GetEntry("options_volume");
        backText.text = mainMenuLang.GetEntry("options_back");
    }


}
