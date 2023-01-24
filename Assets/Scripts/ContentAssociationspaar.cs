using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionEnum
{
    option1 = 1,
    otpion2 = 2,
    option3 = 3,
    option4 = 4,
}

[System.Serializable]
public class ContentAssociationspaar
{
    public string assoziationspaar1;
    public string assoziationspaar2;
    public string assoziationspaar3;
    public string assoziationspaar4;
    public string hinweiswort;
    public string option1;
    public string option2;
    public string option3;
    public string option4;
    public OptionEnum chosenOption;
    public OptionEnum correctOption;
    public int timeToAnswerInSeconds;
    public AudioClip scream;

    public bool AnswerIsCorrect()
    {
        if (timeToAnswerInSeconds > 10)
        {
            return false;
        }
        else
        {
            return chosenOption == correctOption;
        }
    }
}
