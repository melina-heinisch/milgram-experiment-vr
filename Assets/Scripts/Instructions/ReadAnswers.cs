using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAnswers : MonoBehaviour, IInstruction
{
    public bool isDone()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        //new instruction
        canvasReferences.anweisung.text = "Lesen Sie die Antwortmöglichkeiten vor. Schalten Sie danach die Antwortbuttons frei.";
        //make answers visible
        canvasReferences.MakeAnswersWhite();
        canvasReferences.MakeAnswersVisible();
    }
}
