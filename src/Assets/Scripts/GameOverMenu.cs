using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    public static bool gameIsOver = false;
    public GameObject gameOverMenuUI;

    private PlayerController playerController;
    private Lang gameOverLang;

    [SerializeField] private TextMeshProUGUI displayTimerText;
    [SerializeField] private TextMeshProUGUI ingameTimerText;
    [SerializeField] private TextMeshProUGUI resultTimeText;
    [SerializeField] private TextMeshProUGUI toTitleText;


    // Start is called before the first frame update
    void Start()
    {
        gameOverLang = new Lang(PlayerPrefs.GetString("LanguageSetting"));
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        resultTimeText.text = gameOverLang.GetEntry("gameover_time");
        toTitleText.text = gameOverLang.GetEntry("pause_gameover_title");
    }

    // Update is called once per frame
    void Update()
    {

        if(playerController.Health <= 0)
        {
            gameIsOver = true;
        }

        if (gameIsOver)
        {
            displayTimerText.text = ingameTimerText.text;
            Time.timeScale = 0f;
            AudioListener.pause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
        gameOverMenuUI.SetActive(false);
        gameIsOver = false;
    }

}
