using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForAnswer : MonoBehaviour, IInstruction
{
    private ReferenceAssociationCanvas canvas;
    private ContentAssociationspaar _association;
    private bool done;

    public bool isDone()
    {
        //can not be skipped.
        return done;
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        //new instruction
        done = false;
        canvas = canvasReferences;
        _association = assoziation;
        StartCoroutine(InstructionWithCountDown());
    }

    private IEnumerator InstructionWithCountDown()
    {
        int countdown = 10;
        int timeToAnswer;

        if (_association.chosenOption == OptionEnum.none)
        {
            timeToAnswer = 10;
        }
        else
        {
            timeToAnswer = UnityEngine.Random.Range(1, 5);
        }

        while (countdown >= 10 - timeToAnswer) // if 'time to answer' > '10' it will only count to '0'
        {
            canvas.anweisung.text = $"Warten Sie auf die Antwort des Schülers ({countdown})";

            countdown--;
            yield return new WaitForSeconds(1);
        }
        done = true;
    }
}
