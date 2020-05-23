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

    //Show the amount of wasps the player has currently defeated on the UI
    void Start()
    {
        waspCounterText.text = defeatedWasps.ToString();
    }

    //This sets a new highscore when accessed from another script if the player defeats more wasps than before
    public void SetNewWaspHighscore()
    {
        if (PlayerPrefs.GetFloat("WaspHighscore", 0) < defeatedWasps)
        {
            PlayerPrefs.SetFloat("WaspHighscore", defeatedWasps);
        }
    }

    //Increase and display the count of defeated wasps from another script (after a bee has been defeated)
    public void IncreaseWaspCounter()
    {
        defeatedWasps++;
        waspCounterText.text = defeatedWasps.ToString();
    }

}
