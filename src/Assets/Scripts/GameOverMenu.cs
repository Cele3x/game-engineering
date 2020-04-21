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

    [SerializeField] private TextMeshProUGUI displayTimerText;
    [SerializeField] private TextMeshProUGUI ingameTimerText;
    [SerializeField] private TextMeshProUGUI resultTimeText;
    [SerializeField] private TextMeshProUGUI toTitleText;


    // Start is called before the first frame update
    void Start()
    {
        gameOverLang = new Lang(PlayerPrefs.GetString("LanguageSetting"));

        Debug.Log(gameOverLang.GetEntry("gameover_time"));
        Debug.Log(gameOverLang.GetEntry("pause_gameover_title"));

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
