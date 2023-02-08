using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperimenterDialog : MonoBehaviour
{
    [SerializeField] private float volume;
    [SerializeField] private GameObject debriefing;
    [SerializeField] private GameObject associationCanvas;
    [SerializeField] private TextMeshProUGUI debriefingText;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dangerAnswerAudio;
    [SerializeField] private AudioClip weigerungSchueler;
    [SerializeField] private AudioClip noAnswerAudio;
    [SerializeField] private List<AudioClip> exitExperimentAnswers; 
    [SerializeField] private List<string> exitExperimentButtonTexts;

    private int incentivesDone = 0;

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
            // Debug.Log(exitExperimentAnswers[incentivesDone]);
            audioSource.PlayOneShot(exitExperimentAnswers[incentivesDone], volume);

            // increase incentives
            incentivesDone++;
            buttonText.text = exitExperimentButtonTexts[incentivesDone];
        }
    }

    private void Debriefing()
    {
        associationCanvas.SetActive(false);
        debriefingText.text = "Debriefing 1/3 \n \n Dieses Experiment hatte den Zweck zu testen, wie gehorsam man sich gegenüber Autoritätspersonen verhält. " +
                              "Während dem Experiment wurden keine Personen verletzt. Es wurden keine gefählichen Töne abgespielt und ihr virtueller Gegenüber war nur simuliert. " +
                              "Ihr Abbruch zeugt davon, dass sie Mitgefühl für den Schüler gezeigt haben, das ist sehr lobenswert. " +
                              "Bei weiteren Fragen wenden Sie sich im Anschluss an das Experiment an die Versuchsleiter.";
        debriefing.SetActive(true);
        
    }

    public void TellDangerAnswer()
    {
        audioSource.PlayOneShot(dangerAnswerAudio, volume);
        incentivesDone = 1;
    }

    public void TellStudentWantsToExitAnswer()
    {
        audioSource.PlayOneShot(weigerungSchueler, volume);
        incentivesDone = 1;
    }

    public void TellStudentDidntAnswerAnswer()
    {
        audioSource.PlayOneShot(noAnswerAudio, volume);
        //incentives will not increase. See https://gitlab2.informatik.uni-wuerzburg.de/hci/teaching/courses/special-topics-xr/student-materials/2022-winter/light-and-dark-sides-gruppe-1/-/wikis/Methodik%20des%20originalen%20Milgram%20Experiments#reaktionen-bei-nachfragen-durch-versuchsperson
    }
}
