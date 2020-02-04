using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;  

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
           if(GameIsPaused) 
           {
               Resume();
           } else
           {
               Pause();
           }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadTitleScreen()
    {
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
