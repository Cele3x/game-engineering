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
        gameOverLang = new Lang(PlayerPrefs.GetString("LanguageSetting"));

        resultTimeText.text = gameOverLang.GetEntry("gameover_time");
        toTitleText.text = gameOverLang.GetEntry("pause_gameover_title");

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

}
