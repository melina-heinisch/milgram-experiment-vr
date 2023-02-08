using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WholeAssociationTask : MonoBehaviour
{
    [SerializeField] private GameObject debriefingCanvas;
    [SerializeField] private GameObject associationCanvas;
    [SerializeField] private TextMeshProUGUI debriefingText;
    [SerializeField] private ReferenceAssociationCanvas teachterMonitorReferences;

    //Liste mit den Assoziationspaaren & Antworten
    [SerializeField] private List<ContentAssociationspaar> textsForAssociationCanvas;

    //private
    private int associationIndex = 0;
    private List<IInstruction> instructions;
    private int instructionIndex = 0;

    void Start()
    {
        gameObject.AddComponent<InitializeAssoziationspaar>();
        gameObject.AddComponent<ReadAnswers>();
        gameObject.AddComponent<WaitForAnswer>();
        gameObject.AddComponent<IncreaseVolume>();
        gameObject.AddComponent<ReadPunishmentValue>();
        gameObject.AddComponent<ExecutePunishment>();
        gameObject.AddComponent<DelayForNextRound>();

        instructions = new List<IInstruction>
        {
            gameObject.GetComponent<InitializeAssoziationspaar>(),
            gameObject.GetComponent<ReadAnswers>(),
            gameObject.GetComponent<WaitForAnswer>(),
            gameObject.GetComponent<IncreaseVolume>(), //increases volume if there is no answer or answer is wrong. skipped, when answer is correct.
            gameObject.GetComponent<ReadPunishmentValue>(), //skipped when answer is correct
            gameObject.GetComponent<ExecutePunishment>(), //skipped when answer is correct
            gameObject.GetComponent<DelayForNextRound>(), //wait for next words 
        };

        //start the instructions
        instructions[0].OnStartOfInstruction(teachterMonitorReferences, textsForAssociationCanvas[associationIndex]);
    }

    void Update()
    {
        if (instructions[instructionIndex].isDone())
        {
            instructionIndex++;
            if (instructionIndex == instructions.Count)
            {
                instructionIndex = 0;
                associationIndex++;
                //debriefing
                if (associationIndex == textsForAssociationCanvas.Count)
                {
                    associationCanvas.SetActive(false);
                    debriefingText.text = "Debriefing 1 \n \n Dieses Experiment hatte den Zweck zu testen, wie Gehorsam man sich gegenüber Autoritätspersonen verhält. Während dem Experiment wurden keine Personen verletzt. Es wurden keine gefählichen Töne abgespielt und ihr virtueller Gegenüber war nur simuliert. Dass Sie auch trotz Leiden des Schülers weiter gemacht haben, ist eine normale Raktion und kann bei vielen Teilnehmern beobachtet werden. Bei weiteren Fragen wenden Sie sich im Anschluss an das Experiment an die Versuchsleiter.";
                    debriefingCanvas.SetActive(true);
                }
            }

            // show the next instruction
            instructions[instructionIndex].OnStartOfInstruction(teachterMonitorReferences, textsForAssociationCanvas[associationIndex]);
        }
    }
}
