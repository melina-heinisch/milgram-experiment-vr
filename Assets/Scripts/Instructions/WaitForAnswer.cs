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
        Debug.LogWarning("not implemented");
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
        int number = 10;

        while (number >= Math.Max(0, 10 - _association.timeToAnswerInSeconds)) // if 'time to answer' > '10' it will only count to '0'
        {
            canvas.anweisung.text = $"Warten Sie auf die Antwort des Schülers ({number})";

            number--;
            yield return new WaitForSeconds(1);
        }
        done = true;
    }
}
