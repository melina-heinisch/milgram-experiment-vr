using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ReferenceAssociationCanvas
{
    public float volume;
    public AudioSource audioSourceSpeaker;
    public AudioSource audioSourceVL;
    public AudioClip audioBitteMachenSieWeiter;
    public TextMeshProUGUI anweisung;
    public TextMeshProUGUI assoziationspaar1;
    public TextMeshProUGUI assoziationspaar2;
    public TextMeshProUGUI assoziationspaar3;
    public TextMeshProUGUI assoziationspaar4;
    public TextMeshProUGUI hinweiswort;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;

    public void MakeAssociationspaareVisible()
    {
        assoziationspaar1.gameObject.SetActive(true);
        assoziationspaar2.gameObject.SetActive(true);
        assoziationspaar3.gameObject.SetActive(true);
        assoziationspaar4.gameObject.SetActive(true);
        hinweiswort.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
    }

    public void MakeAnswersVisible()
    {
        assoziationspaar1.gameObject.SetActive(false);
        assoziationspaar2.gameObject.SetActive(false);
        assoziationspaar3.gameObject.SetActive(false);
        assoziationspaar4.gameObject.SetActive(false);
        hinweiswort.gameObject.SetActive(true);
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
        option3.gameObject.SetActive(true);
        option4.gameObject.SetActive(true);
    }

    public void MakeAssoziationspaareAndAnswersNonVisible()
    {
        assoziationspaar1.gameObject.SetActive(false);
        assoziationspaar2.gameObject.SetActive(false);
        assoziationspaar3.gameObject.SetActive(false);
        assoziationspaar4.gameObject.SetActive(false);
        hinweiswort.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
    }

    public void MakeAnswersWhite()
    {
        option1.color = Color.white;
        option2.color = Color.white;
        option3.color = Color.white;
        option4.color = Color.white;
    }

    public void ColorAnswer(int option, Color color)
    {
        if (option == 1)
        {
            option1.color = color;
        }
        else if (option == 2)
        {
            option2.color = color;
        }
        else if (option == 3)
        {
            option3.color = color;
        }
        else if (option == 4)
        {
            option4.color = color;
        }
    }
}
