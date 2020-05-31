using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogManager : MonoBehaviour {

 
    private int instructionStep = 0;

    [SerializeField] 
    private TMP_Text dialogField = null;
    [SerializeField] 
    private GameObject currentlyHighlighted = null;
    [SerializeField] 
    private GameObject continueButton = null;
    [SerializeField]
    private TextMeshProUGUI instructionsText = null;
    [SerializeField]
    private TextMeshProUGUI mainMenuText = null;
    [SerializeField]
    private TextMeshProUGUI startGameText = null;

    private string forward;
    private string startOver;

    private string[] lines;
    private readonly string[] germanLines = new[] { "Willkommen zum Tutorial. Hier wird erklärt, wie das Spiel funktioniert.", 
        "Starten wir bei der Steuerung:\n    [W]\n[A][S][D]     =  Laufen\nLinksklick    =  Angreifen\nRechtsklick  =  Power-up\n[ESC]         =  Pause\nDie Mausbelegung kann in den Optionen umgekehrt werden.",
        "Dies ist eine Wespe. Vorsicht ist geboten, sie ist aggressiv und will den Spieler stechen! Schlagen Sie mit Ihrer Klatsche zu, bevor Sie gestochen werden!",
        "Diese Anzeige zählt alle Wespen, die im aktuellen Durchgang eliminiert wurden. Können Sie den Highscore schlagen?",
        "Dies ist die Lebensanzeige. Sie zeigt an, wie viele Leben aktuell übrig sind. Wird man von einer Wespe gestochen, wird ein Leben abgezogen. Wenn keine Leben mehr übrig sind, ist das Spiel vorbei. So einfach ist das.",
        "Hin und wieder taucht im Spiel ein Spray wie dieses hier auf. Wenn man es einsammelt, kann man mit der rechten Maustaste einen giftigen Nebel versprühen. Wespen hassen Insektenspray, es macht sie ganz langsam und träge.",
        "Schon Oma wusste, dass Zwiebeln gegen Wespenstiche helfen. Beim Aufsammeln von Zwiebeln erhält man ein Leben zurück. Genau wie die Sprühdosen müssen sie auf dem gesamten Grundstück erst einmal gesucht und gefunden werden .",
        "Das war alles fürs Erste.  Sobald Sie bereit sind, können Sie mit einem Klick auf SPIEL STARTEN in die Welt von Angry Stingers eintauchen."
    };
    private readonly string[] englishLines = new[] { "Welcome to the Instructions section. This section will explain how the game works. ",
        "Let's start with the controls:\n    [W]\n[A][S][D]     =  Moving\nLeft click    =  Attack\nRight click  =  Power-up\n[ESC]         =  Pause\nThe mouse controls can be reversed in the options menu.",
        "This is a wasp. Beware of it, it is aggressive and wants to sting the player! Better hit it with your swatter before you get stung!",
        "This display counts all the wasps that were defeated during the current run. Can you beat the highscore?",
        "This is the healthbar. It shows your current health. If a bee stings you, you lose one life. The game ends when no lives are left anymore. It's as simple as that.",
        "Sometimes an insect spray like this one will appear. After picking it up, the right mouse button can be used to emit a toxic mist. Wasps hate insect spray, it makes them slow and sluggish.",
        "Grandma already knew that onions help against wasp stings. Gathering an onion gains one extra live. Similar to the spray cans, you have to carefully search for them and find them on the premises",
        "That is all for now. As soon as you are ready, you can start the game by clicking on START GAME and dive right into the world of Angry Stingers.",};

    // Use this for initialization
    void Start () {
        
        string lang = PlayerPrefs.GetString("LanguageSetting", "English");

        if (lang == "German")
        {
            lines = germanLines;
            forward = "> Nächster Tipp";
            startOver = "Bitte Nochmal";

            instructionsText.text = "Anleitung";
            mainMenuText.text = "Hauptmenü";
            startGameText.text = "Spiel starten";
        } else
        {
            lines = englishLines;
            forward = "> Next Tip";
            startOver = "Explain again";

            instructionsText.text = "Instructions";
            mainMenuText.text = "Main menu";
            startGameText.text = "Start game";
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
