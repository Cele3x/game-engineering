using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaspCounter : MonoBehaviour

{

    [SerializeField]
    private TextMeshProUGUI waspCounterText = null;

    private int defeatedWasps;

    // Update is called once per frame
    void Update()
    {
        waspCounterText.text = defeatedWasps.ToString();
    }

    public void SetNewWaspHighscore()
    {
        if (PlayerPrefs.GetFloat("WaspHighscore", 0) < defeatedWasps)
        {
            PlayerPrefs.SetFloat("WaspHighscore", defeatedWasps);
        }
    }

    public void IncreaseWaspCounter()
    {
        defeatedWasps++;
    }

}
