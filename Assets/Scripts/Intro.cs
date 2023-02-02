using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject vlInteraction;
    [SerializeField] private GameObject monitorCanvas;
    [SerializeField] private GameObject schieberegler;
    [SerializeField] private GameObject roleCanvas;
    [SerializeField] private GameObject studentImage;

    [SerializeField] private float volume;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip transition;

    Schieberegler script_regler;
    WholeAssociationTask script_association;

    private bool intro_played = false;

    // Start is called before the first frame update
    void Start()
    {
        script_regler = schieberegler.GetComponent<Schieberegler>();
        script_association = monitorCanvas.GetComponent<WholeAssociationTask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !intro_played)
        {
            intro_played = true;
            StartCoroutine(playIntro());
        }

    }

    IEnumerator playIntro()
    {
        audiosource.PlayOneShot(intro, volume);
        yield return new WaitForSeconds(intro.length);
        roleCanvas.SetActive(true);
        yield return new WaitForSeconds(3);
        audiosource.PlayOneShot(transition, volume);
        yield return new WaitForSeconds(5);
        roleCanvas.SetActive(false);
        studentImage.SetActive(true);
        yield return new WaitForSeconds(transition.length - 5);
        studentImage.SetActive(false);
        IsDone();
    }

    void IsDone()
    {
        vlInteraction.SetActive(true);
        monitorCanvas.SetActive(true);
        script_regler.enabled = true;
        script_association.enabled = true;
    }
}
