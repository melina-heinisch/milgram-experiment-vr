using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WholeAssociationTask : MonoBehaviour
{
    [SerializeField] private GameObject debriefingCanvas;
    //references unity objects
    [SerializeField] private ReferenceAssociationCanvas teachterMonitorReferences;

    //Liste mit den Assoziationspaaren & Antworten
    [SerializeField] private List<ContentAssociationspaar> textsForAssociationCanvas;

    //private
    private int associationIndex = 0;
    private List<IInstruction> instructions;
    private int instructionIndex = 0;


    // Start is called before the first frame update
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
            gameObject.GetComponent<ExecutePunishment>(), //do punishment. skipped when answer is correct.
            gameObject.GetComponent<DelayForNextRound>(), //wait for next words (differen text when answer is correct?)
        };

        //start the instructions
        instructions[0].OnStartOfInstruction(teachterMonitorReferences, textsForAssociationCanvas[associationIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (instructions[instructionIndex].isDone())
        {
            Debug.Log($"Instruction done");
            instructionIndex++;
            if (instructionIndex == instructions.Count)
            {
                instructionIndex = 0;
                associationIndex++;
                //debriefing
                if (associationIndex == textsForAssociationCanvas.Count)
                {
                    debriefingCanvas.SetActive(true);
                }
            }

            // show the next instruction
            instructions[instructionIndex].OnStartOfInstruction(teachterMonitorReferences, textsForAssociationCanvas[associationIndex]);
        }
    }
}
