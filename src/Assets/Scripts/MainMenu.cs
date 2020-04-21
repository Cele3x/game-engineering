using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
    private Lang mainMenuLang;

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
        mainMenuLang = new Lang(Path.Combine(Application.dataPath, "lang.xml"), "English", false);
    }


}
