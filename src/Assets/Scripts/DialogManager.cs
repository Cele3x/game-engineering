using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogManager : MonoBehaviour {

 
    private int instructionStep = 0;

    [SerializeField] private TMP_Text dialogField;
    [SerializeField] private GameObject currentlyHighlighted;
    [SerializeField] private GameObject continueButton;

    private string forward;
    private string startOver;

    private string[] lines;
    private readonly string[] germanLines = new[] { "Willkommen zum Tutorial. Hier erfahren Sie, wie das Spiel funktioniert.", 
        "Starten wir bei der Steuerung:\n    [W]\n[A][S][D]     =  Laufen\nLinksklick    =  Angreifen\nRechtsklick  =  Power-up\n[ESC]         =  Pause\nDu kannst die Mausbelegung in den Optionen umkehren.",
        "Dies ist eine Wespe. Hüten Sie sich vor ihr, sie ist aggressiv und will Sie stechen! Schlagen Sie besser mit Ihrer Klatsche zu, bevor sie Sie tötet!",
         "Diese Anzeige zählt alle Wespen, die Sie im  aktuellen Durchgang eliminiert haben. Können Sie den Highscore toppen?",
                 "Das hier zeigt Ihren aktuellen Gesundheitszustand an. Wenn Sie von einer Biene gestochen werden, verlieren Sie ein Leben. Wenn Sie keine Leben mehr haben, verlieren Sie das Spiel. So einfach ist das.",
        "Wenn Sie Glück haben, finden Sie ein Spray wie dieses hier. Laufen Sie durch, um es aufzunehmen, und versprühen Sie mit der rechten Maustaste giftiges Insektenspray. Wespen hassen diesen Trick, es macht sie ganz langsam und träge.",
        "Schon Oma wusste, dass Zwiebeln gegen Wespenstiche helfen. Sammeln Sie Zwiebeln und erhalten Sie ein Leben zurück. Wie bei den Sprühdosen muss man sie im ganzen Areal gut suchen.",
         "Das war's fürs Erste, legen Sie gleich los, indem Sie auf den Start-Button unten rechts klicken, sobald Sie bereit sind."
    };
    private readonly string[] englishLines = new[] { "Welcome to the Instructions Section. Here you will learn how the game works. ",
        "Let's start with the controls:\n    [W]\n[A][S][D]     =  Moving\nLeft click    =  Attack\nRight click  =  Power-up\n[ESC]         =  Pause\nYou can reverse mouse controls in the options menu.",
        "This is a wasp. Beware of it, it is aggressive and wants to sting you! Better hit it with your swatter before it kills you!",
        "This Display keeps count of all the wasps you have defeated during the current run. Can you beat the highscore?",
        "This is your healthbar. It shows your current health. You lose one live if a bee stings you. If you dont have any lives left you loose the game. It's as simple as that.",
    "Sometimes you'll be lucky and find an insect spray like this one here. Run through it to pick it up and use your right mouse button to emit toxic insect spray. Wasps hate that trick, it makes them so slow.",
    "Grandma already knew that onions help fight wasp stings. Gather onions and gain extra health. Like the spray cans, you have to look for them carefully in the whole area",
    "Thats all for now, dive right into it by clicking the start button in the bottom right, when you are ready!",};

    // Use this for initialization
    void Start () {
        
        string lang = PlayerPrefs.GetString("LanguageSetting", "English");

        if (lang == "German")
        {
            lines = germanLines;
            forward = "> Weiter";
            startOver = "Bitte Nochmal";
        } else
        {
            lines = englishLines;
            forward = "> Next Tipp";
            startOver = "Explain again";
        }
        continueButton.GetComponentInChildren<TMP_Text>().SetText(forward);
        dialogField.SetText(lines[0]);

    }

    public void StartDialog(Dialog dialog)


    {
        dialogField.SetText(lines[instructionStep]);

        if (instructionStep == 7)
        {
            currentlyHighlighted.SetActive(false);
            continueButton.GetComponentInChildren<TMP_Text>().SetText(startOver);
            instructionStep = 0;
        }

        if (instructionStep == 6)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(3247, -938, 0);
        }

        if (instructionStep == 5)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-831, -1073, 0);
        }

        if (instructionStep==4)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(4211, 1080, 0);
        }

        if(instructionStep==3)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-1675, 1080, 0);
        }

        if (instructionStep == 2)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(1396, -941, 0);
        }

        if (instructionStep ==1)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-3824, 759, 0);
            continueButton.GetComponentInChildren<TMP_Text>().SetText(forward);
            currentlyHighlighted.SetActive(true);
        }

        instructionStep++;

    }



}
