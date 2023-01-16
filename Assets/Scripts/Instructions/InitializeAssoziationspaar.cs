using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAssoziationspaar : MonoBehaviour, IInstruction
{
    private PressButtonAnimation microphoneButton;
    private bool buttonHasBeenActivated;

    private void Start()
    {
        microphoneButton = GameObject.Find("Button Microphone").GetComponentInChildren<PressButtonAnimation>();
    }

    public bool isDone()
    {
        if (microphoneButton.buttonIsPressed)
        {
            buttonHasBeenActivated = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) ||
            (buttonHasBeenActivated && !microphoneButton.buttonIsPressed)) //wait until button is released
        {
            //reset bool
            buttonHasBeenActivated = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        Debug.Log("Start of instruction Init.");
        //set instruction
        canvasReferences.anweisung.text = "Halten Sie den Knopf vor dem Mikrofon gedrückt und lesen Sie die Wortpaare vor.";

        //set other texts
        canvasReferences.assoziationspaar1.text = assoziation.assoziationspaar1;
        canvasReferences.assoziationspaar2.text = assoziation.assoziationspaar2;
        canvasReferences.assoziationspaar3.text = assoziation.assoziationspaar3;
        canvasReferences.assoziationspaar4.text = assoziation.assoziationspaar4;
        canvasReferences.hinweiswort.text = assoziation.hinweiswort;
        canvasReferences.option1.text = assoziation.option1;
        canvasReferences.option2.text = assoziation.option2;
        canvasReferences.option3.text = assoziation.option3;
        canvasReferences.option4.text = assoziation.option4;

        //make sure that the right words are visible
        canvasReferences.MakeAssociationspaareVisible();
    }
}
