using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePunishment : MonoBehaviour, IInstruction
{
    ContentAssociationspaar _association;
    private PressButtonAnimation punishButton;

    private void Start()
    {
         punishButton = GameObject.Find("Button Punish").GetComponentInChildren<PressButtonAnimation>();
    }

    public bool isDone()
    {
        //skip this step if answer is correct
        if (_association.correctOption == _association.chosenOption && _association.timeToAnswerInSeconds <= 10)
        {
            return true;
        }
        // is punishment done?
        if (Input.GetKeyDown(KeyCode.Space) || punishButton.buttonIsPressed)
        {
            Debug.LogWarning("Sound not implemented");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        _association = assoziation;
        canvasReferences.anweisung.text = "Bitte lesen Sie die Höhe der Strafe vor und führen Sie die Strafe durch.";
    }
}
