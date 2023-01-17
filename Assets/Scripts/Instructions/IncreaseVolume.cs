using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IncreaseVolume : MonoBehaviour, IInstruction
{
    private Schieberegler schieberegler;
    private int previousVolume;
    private bool answerIsCorrect;

    void Start()
    {
        schieberegler = GameObject.Find("Slider Grip").GetComponentInChildren<Schieberegler>();
    }

    public bool isDone()
    {
        if (answerIsCorrect)
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) || schieberegler.value > previousVolume)
        {
            Debug.LogWarning("not implemented");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        //set previous value
        previousVolume = schieberegler.value;
        answerIsCorrect = assoziation.AnswerIsCorrect();

        if (assoziation.timeToAnswerInSeconds > 10) // Zeit abgelaufen
        {
            canvasReferences.anweisung.text = "Die Zeit ist abgelaufen.\nBitte erhöhen Sie die Lautstärke.";
            canvasReferences.ColorAnswer(1, Color.red);
            canvasReferences.ColorAnswer(2, Color.red);
            canvasReferences.ColorAnswer(3, Color.red);
            canvasReferences.ColorAnswer(4, Color.red);
        }
        else if (assoziation.chosenOption != assoziation.correctOption) // Antwort falsch
        {
            canvasReferences.anweisung.text = "Die Antwort ist falsch.\nBitte erhöhen Sie die Lautstärke.";
            canvasReferences.ColorAnswer((int)assoziation.chosenOption, Color.red);
            canvasReferences.ColorAnswer((int)assoziation.correctOption, Color.green);
        }
        //else // Antwort richtig
        //{
        //    canvasReferences.anweisung.text = "Die Antwort ist korrekt.\nBitte klicken Sie XXX um fortzufahren.";
        //    canvasReferences.ColorAnswer((int)assoziation.correctOption, Color.green);
        //}
    }

}
