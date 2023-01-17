using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPunishmentValue : MonoBehaviour, IInstruction
{
    private PressButtonAnimation microphoneButton;
    private bool buttonHasBeenActivated;
    private bool answerIsCorrect;

    private void Start()
    {
        microphoneButton = GameObject.Find("Button Microphone").GetComponentInChildren<PressButtonAnimation>();
    }

    public bool isDone()
    {
        if (answerIsCorrect)
        {
            return true;
        }
        else
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
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        answerIsCorrect = assoziation.AnswerIsCorrect();
        if (!answerIsCorrect)
        {
            canvasReferences.anweisung.text = "Bitte lesen Sie die Höhe der Strafe vor.";
        }
    }
}
