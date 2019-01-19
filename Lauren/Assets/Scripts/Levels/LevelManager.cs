using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sound;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    [SerializeField]
    private GameObject activeStep;
    private GameObject lastStep;

    [SerializeField]
    public Step[] steps;

    public string currentZone;
    private bool stayActive;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Use this for initialization
    void Start () {
        activeStep = null;
        foreach (Step s in steps)
        {
            s.StepGameObject.SetActive(false);
        }

    }

    private IEnumerator StartDissolveAppearFx(Step nextStep)
    {
        Debug.Log("next step: " + nextStep.name);
        // Wait 2 seconds then stop the active step
        if (activeStep && !stayActive)
        {
            this.GetComponent<Dissolve>().IsActive = true;

            yield return new WaitForSeconds(3.5f);

            lastStep.SetActive(false);
            
            this.GetComponent<Dissolve>().IsActive = true;
            nextStep.StepGameObject.SetActive(true);
        }
    }
    
    public void OnSpeechEnd(string soundItem, Step nextStep)
    {
        if (!nextStep.isIntro)
            StartCoroutine(StartDissolveAppearFx(nextStep));
    }

    public IEnumerator StartStep(string name)
    {
        Step nextStep = Array.Find(steps, step =>step.name == name);

        if (nextStep.isIntro)
        {
            nextStep.StepGameObject.SetActive(true);
        }
        
        AudioManager.instance.ItemValidation(nextStep.soundItem,
            new EventCbCookie(nextStep.soundItem, nextStep, nextStep.isIntro, nextStep.sceneTrack));

        // The new active step
        lastStep = activeStep;
        activeStep = nextStep.StepGameObject;
        stayActive = nextStep.stayActive;

        yield return null;
    }
}
