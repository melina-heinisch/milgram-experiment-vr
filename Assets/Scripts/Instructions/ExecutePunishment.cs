using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePunishment : MonoBehaviour, IInstruction
{
    private PressButtonAnimation punishButton;
    private bool answerIsCorrect;
    private float volume;
    private AudioClip scream;
    private AudioSource audioSource;

    private void Start()
    {
        punishButton = GameObject.Find("Button Punish").GetComponentInChildren<PressButtonAnimation>();
    }

    public bool isDone()
    {
        //skip this step if answer is correct
        if (answerIsCorrect)
        {
            return true;
        }
        // is punishment done?
        if (Input.GetKeyDown(KeyCode.Space) || punishButton.buttonIsPressed)
        {
            audioSource.PlayOneShot(scream, volume);
            //Debug.LogWarning("Execute punishment. Sound not implemented");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation)
    {
        volume = canvasReferences.volume;
        scream = assoziation.scream;
        audioSource = canvasReferences.audioSource;
        answerIsCorrect = assoziation.AnswerIsCorrect();
        if (!answerIsCorrect)
        {
            canvasReferences.anweisung.text = "Bitte führen Sie die Strafe durch.";
        }
    }
}
