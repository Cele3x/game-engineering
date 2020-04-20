using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    //[SerializeField] MouseLook m_MouseLook;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
           if(!GameIsPaused) 
           {
               Pause();
           }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
        //GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GameIsPaused = true;
        //GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
    }

    public void LoadTitleScreen()
    {
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

}
