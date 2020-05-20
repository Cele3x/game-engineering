using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {

    private Queue<string> sentences;
    private int instructionStep = 0;

    [SerializeField] private TMP_Text dialogField;
    [SerializeField] private GameObject currentlyHighlighted;
    [SerializeField] private GameObject continueButton;

	// Use this for initialization
	void Start () {

        sentences = new Queue<string>();
	}


    public void StartDialog(Dialog dialog)


    {
        if (instructionStep == 4)
        {
            dialogField.SetText("Thats all for now, dive right into it by clicking the start button in the bottom right, when you are ready!");
            currentlyHighlighted.SetActive(false);
            continueButton.SetActive(false);
            Debug.Log(instructionStep);
        }


        if (instructionStep==3)
        {
            dialogField.SetText("This is your healthbar. It shows your current health. You lose one live if a bee stings you. If you dont have any lives left you loose the game. It's as simple as that.");
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(1133, 1756, 0);
            //currentlyHighlighted.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 163);
            instructionStep++;
            Debug.Log(instructionStep);
        }


        if(instructionStep==2)
        {
            dialogField.SetText("This Display keeps count of all the wasps you have killed during the current run. Can you beat the highscore?");
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-4853, 1728, 0);
            //currentlyHighlighted.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 198);
            instructionStep++;
            Debug.Log(instructionStep);

        }

        if (instructionStep == 1)
        {
            dialogField.SetText("Sometimes you'll be lucky to find an insect spray like this one here. Run through it to pick it up and use your right mouse button to emit toxic insect spray. Wasps hate it, it makes them dizzy.");
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-2253, 137, 0);
            instructionStep++;
            Debug.Log(instructionStep);
        }


        if (instructionStep ==0)
        {
            dialogField.SetText("This is a wasp. Be aware of it, it is aggressive and wants to sting you! Better hit it with your swatter before it kills you!");
            currentlyHighlighted.GetComponent<Transform>().localPosition = new Vector3(-3824, 759, 0);
            instructionStep++;
            Debug.Log(instructionStep);

        }

    }



}
