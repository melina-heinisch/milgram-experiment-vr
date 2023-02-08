using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debriefing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debriefingText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        showDebriefing();
    }

    IEnumerator showDebriefing()
    {
        yield return new WaitForSeconds(20);
        debriefingText.text = "Debriefing 2 \n \n Das Experiment war eine Replikation des Milgram Experiments, welches die Gehorsamkeit gegenüber Authoritätspersonen untersucht hat. Dort wurden statt lauten Tönen Stromschläge verabreicht. Das Experiment ist sehr umstritten und ethisch bedenklich, da man im Glauben ist eine Person ernsthaft zu verletzten. Ziel dieser Studie war es zu testen, ob ähnliche Effekte auch in VR auftreten.";
        yield return new WaitForSeconds(20);
        debriefingText.text = "Debriefing 3 \n \n Während dem Experiment bestand zu jedem Zeitpunkt die Möglichkeit abzubrechen, allerdings war es hierfür nötig den virtuellen Versuchsleiter fünf Mal nacheinander darum zu bitten. Wir betonen nochmal, dass in diesem Experient keine Personen zu Schaden gekommen sind, Sie haben niemandem Schmerzen zugefügt und es war alles simuliert. \n Das Experiment ist nun zu Ende, sie können die VR Brille abnehmen";
    }
}
