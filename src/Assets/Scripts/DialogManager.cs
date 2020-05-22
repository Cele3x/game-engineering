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

    private string[] lines;
    private readonly string[] germanLines = new[] { "Willkommen zum Tutorial. Hier erfahren Sie, wie das Spiel funktioniert.", 
        "Dies ist eine Wespe. Hüten Sie sich vor ihr, sie ist aggressiv und will Sie stechen! Schlagen Sie besser mit Ihrer Klatsche zu, bevor sie Sie tötet!",
        "Wenn Sie Glück haben, finden Sie ein Insektenspray wie dieses hier. Laufen Sie durch, um es aufzunehmen, und versprühen Sie mit der rechten Maustaste giftiges Insektenspray. Wespen hassen es, es macht sie ganz benommen.",
        "Diese Anzeige zählt alle Wespen, die Sie im  aktuellen Durchgang getötet haben. Können Sie den Highscore schlagen?",
        "Das hier zeigt Ihren aktuellen Gesundheitszustand an. Wenn Sie von einer Biene gestochen werden, verlieren Sie ein Leben. Wenn Sie keine Leben mehr haben, verlieren Sie das Spiel. So einfach ist das.",
         "Das war's fürs Erste, legen Sie gleich los, indem Sie auf den Start-Button unten rechts klicken, sobald Sie bereit sind."
    };
    private readonly string[] englishLines = new[] { "Welcome to the Instructions Section. Here you will learn how the game works. ",
        "This is a wasp. Beware of it, it is aggressive and wants to sting you! Better hit it with your swatter before it kills you!",
    "Sometimes you'll be lucky to find an insect spray like this one here. Run through it to pick it up and use your right mouse button to emit toxic insect spray. Wasps hate it, it makes them dizzy.",
    "This Display keeps count of all the wasps you have killed during the current run. Can you beat the highscore?",
    "This is your healthbar. It shows your current health. You lose one live if a bee stings you. If you dont have any lives left you loose the game. It's as simple as that.",
    "Thats all for now, dive right into it by clicking the start button in the bottom right, when you are ready!",};

    // Use this for initialization
    void Start () {
        
        string lang = PlayerPrefs.GetString("LanguageSetting");

        if (lang == "German")
        {
            lines = germanLines;
            continueButton.GetComponentInChildren<TMP_Text>().SetText("> Weiter");
        } else
        {
            lines = englishLines;
        }

        dialogField.SetText(lines[0]);

    }

    public void StartDialog(Dialog dialog)


    {
        dialogField.SetText(lines[instructionStep]);

        if (instructionStep == 5)
        {
            currentlyHighlighted.SetActive(false);
            continueButton.SetActive(false);
        }

        if (instructionStep==4)
        {
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(1133, 1756, 0);
            //currentlyHighlighted.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 163);

        }

        if(instructionStep==3)
        {
            dialogField.SetText(lines[instructionStep]);
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-4853, 1728, 0);
            //currentlyHighlighted.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 198);

        }

        if (instructionStep == 2)
        {
            dialogField.SetText(lines[instructionStep]);
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-2253, 137, 0);


        }

        if (instructionStep ==1)
        {
            dialogField.SetText(lines[instructionStep]);
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-3824, 759, 0);


        }

        instructionStep++;

    }



}
