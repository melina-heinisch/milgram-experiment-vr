using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperimenterDialog : MonoBehaviour
{
    [SerializeField] private GameObject debriefing;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private List<string> exitExperimentAnswers; // will be assigned in Inspector. This has to be replaced by audio files.
    [SerializeField] private List<string> exitExperimentButtonTexts;

    private int incentivesDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (exitExperimentAnswers.Count != (exitExperimentButtonTexts.Count - 1))
        //there has to be one question more than answers becaus last answer is triggering the debriefing
        {
            Debug.LogWarning("the length of experiment Answers and experiment Button Texts dont fit together. There has to be one question more than answers becaus last answer is triggering the debriefing");
        }
        buttonText.text = exitExperimentButtonTexts[0];
    }

    public void TellExitExperimentAnswer()
    {
        if (incentivesDone == exitExperimentAnswers.Count)
        {
            Debriefing();
        }
        else
        {
            Debug.Log(exitExperimentAnswers[incentivesDone]);
            buttonText.text = exitExperimentButtonTexts[incentivesDone];
            Debug.LogWarning("Audio muss noch eingebunden werden.");

            // increase incentives
            incentivesDone++;
        }
    }

    private void Debriefing()
    {
        debriefing.SetActive(true);
    }

    public void TellDangerAnswer()
    {
        Debug.Log("Die Schocks mögen äußerts schmerzhaft sein, sie hinterlassen aber keine bleibenden Gewebeschädigungen. Machen sie also weiter!");
        Debug.LogWarning("Audio muss noch eingebunden werden.");
        incentivesDone = 1;
    }

    public void TellStudentWantsToExitAnswer()
    {
        Debug.Log("Ob es dem Schüler passt oder nicht, sie müssen weitermachen, bis er alle Wortpaare exakt gelernt hat. Fahren sie also fort!");
        Debug.LogWarning("Audio muss noch eingebunden werden.");
        incentivesDone = 1;
    }

    public void TellStudentDidntAnswerAnswer()
    {
        Debug.Log("Regelmäßige Anweisung, keine Antwort als falsch zu werten und dementsprechend zu bestrafen, Toleranzzeit von 5 - 10 Sekunden");
        Debug.LogWarning("Audio muss noch eingebunden werden.");
        //incentives will not increase. See https://gitlab2.informatik.uni-wuerzburg.de/hci/teaching/courses/special-topics-xr/student-materials/2022-winter/light-and-dark-sides-gruppe-1/-/wikis/Methodik%20des%20originalen%20Milgram%20Experiments#reaktionen-bei-nachfragen-durch-versuchsperson
    }
}
