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

    //Initiates the main menu with default or saved audio level and resets the time, audio and cursor
    void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    //Check which language is currently set in the options menu and change to that language, the default language is english
    void Update()
    {
        if (PlayerPrefs.GetString(langKey, langDefault) == "German")
        {
            ChangeMainMenuLanguageToGerman();

        }
        else if (PlayerPrefs.GetString(langKey, langDefault) == "English")
        {
            ChangeMainMenuLanguageToEnglish();
        }
    }

    //Start the game after pressing a button in the main menu(the game is the next scene after the main menu) 
    //and disable the cursor, because it is only needed in the menus
    public void PlayGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Close the game after pressing a button in the main menu
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Additive);
    }

    //Switches the language on the press of the switch language button in the options menu to the other language 
    //and set that language as the new preference
    public void SwitchLanguage()
    {

        if (PlayerPrefs.GetString(langKey, langDefault) == "English")
        {
            PlayerPrefs.SetString(langKey, "German");
            ChangeMainMenuLanguageToGerman();
        }
        else if (PlayerPrefs.GetString(langKey, langDefault) == "German")
        {
            PlayerPrefs.SetString(langKey, "English");
            ChangeMainMenuLanguageToEnglish();
        }
    }

    //Change all texts in the main menu to german
    public void ChangeMainMenuLanguageToGerman()
    {
        optionsText.text = "Optionen";
        quitText.text = "Beenden";
        optionsTitleText.text = "Optionen";
        volumeText.text = "Lautstärke";
        backText.text = "Zurück";
        languageText.text = "Sprache Wechseln";
        languageButtonText.text = "Englisch";
        controlsText.text = "Maussteuerung Umkehren";

        //set button text according to the current mouse layout
        if (PlayerPrefs.GetString(controlKey, "defaultControls") == "defaultControls")
        {
            controlsButtonText.text = "Angreifen/Sprühen";
        }
        else if (PlayerPrefs.GetString(controlKey, "defaultControls") == "altControls")
        {
            controlsButtonText.text = "Sprühen/Angreifen";
        }
    }

    //Change all texts in the main menu to english
    public void ChangeMainMenuLanguageToEnglish()
    {
        optionsText.text = "Options";
        quitText.text = "Quit";
        optionsTitleText.text = "Options";
        volumeText.text = "Volume";
        backText.text = "Back";
        languageText.text = "Switch Language";
        languageButtonText.text = "German";
        controlsText.text = "Reverse Mouse Controls";

        //set button text according to the current mouse layout
        if (PlayerPrefs.GetString(controlKey, "defaultControls") == "defaultControls")
        {
            controlsButtonText.text = "Attack/Spray";
        }
        else if (PlayerPrefs.GetString(controlKey, "defaultControls") == "altControls")
        {
            controlsButtonText.text = "Spray/Attack";
        }
    }

    //This changes the mouse control after pressing a button in the options menu to default or alternate controls
    public void ChangeMouseControls()
    {
        //if default controls are enabled, after a button click, switch to and show alternate chontrols
        if (PlayerPrefs.GetString(controlKey, "defaultControls") == "defaultControls")
        {
            PlayerPrefs.SetString(controlKey, "altControls");
            ControlSchemeText("Spray/Attack", "Sprühen/Angreifen");
        }
        //if alternate controls are enabled, after a button click, switch to and show default controls
        else if (PlayerPrefs.GetString(controlKey, "defaultControls") == "altControls")
        {
            PlayerPrefs.SetString(controlKey, "defaultControls");
            ControlSchemeText("Attack/Spray", "Angreifen/Sprühen");
        }
    }

    //This changes the text of the control button in the options menu depending on the currently set language 
    public void ControlSchemeText(string engText, string gerText)
    {
        if (PlayerPrefs.GetString(langKey, langDefault) == "English")
        {
            controlsButtonText.text = engText;
        } 
        else if (PlayerPrefs.GetString(langKey, langDefault) == "German")
        {
            controlsButtonText.text = gerText;
        }
    }

}
