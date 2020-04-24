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

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            uiText.text = timer.ToString("F");
    }

    public void setNewHighscore()
    {
        if (PlayerPrefs.GetFloat("Highscore", 0) < timer)
        {
            PlayerPrefs.SetFloat("Highscore", timer);
        }
    }

}
