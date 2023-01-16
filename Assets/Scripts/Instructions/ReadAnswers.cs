using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAnswers : MonoBehaviour, IInstruction
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
        //new instruction
        canvasReferences.anweisung.text = "Lesen Sie die Antwortmöglichkeiten vor."; //previous "Lesen Sie die Antwortmöglichkeiten vor. Schalten Sie danach die Antwortbuttons frei."
        //make answers visible
        canvasReferences.MakeAnswersWhite();
        canvasReferences.MakeAnswersVisible();
    }
}
