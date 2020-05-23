using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] 
    private TextMeshProUGUI uiText = null;

    private float timer;

    // Initialize the timer and show the passed time on the UI
    void Update()
    {
            timer += Time.deltaTime;
            uiText.text = timer.ToString("F");
    }

    //This sets a new highscore when accessed from another script if the player survived longer than before
    public void SetNewHighscore()
    {
        if (PlayerPrefs.GetFloat("Highscore", 0) < timer)
        {
            PlayerPrefs.SetFloat("Highscore", timer);
        }
    }

}
