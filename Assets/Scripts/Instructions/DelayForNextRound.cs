using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayForNextRound : MonoBehaviour, IInstruction
{
    private bool done;
    private ContentAssociationspaar _association;
    private ReferenceAssociationCanvas canvas;

    public bool isDone()
    {
        //can not be skipped.
        Debug.LogWarning("not implemented");
        return done;
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        done = false;
        canvas = canvasReferences;
        _association = assoziation;
        StartCoroutine(InstructionWithCountDown());
        //canvasReferences.MakeAssoziationspaareAndAnswersNonVisible();
    }

    private IEnumerator InstructionWithCountDown()
    {
        int number = 3;

        while (number >= 0) // if 'time to answer' > '10' it will only count to '0'
        {
            if (_association.AnswerIsCorrect())
            {
                canvas.anweisung.text = $"Die Antwort ist korrekt. Der nächste Durchgang startet in {number} Sekunden.";
            }
            else
            {
                canvas.anweisung.text = $"Der nächste Durchgang startet in {number} Sekunden.";
            }

            number--;
            yield return new WaitForSeconds(1);
        }
        done = true;
    }
}

