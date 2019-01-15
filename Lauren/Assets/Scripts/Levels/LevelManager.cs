using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sound;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    [SerializeField]
    private GameObject activeStep;

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
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator StartStep(string name)
    {
        Step nextStep = Array.Find(steps, step =>step.name == name);

        nextStep.StepGameObject.SetActive(true);
        // Wait 2 seconds then stop the active step
        if (activeStep != null && !stayActive)
        {
                yield return new WaitForSeconds(1f);
                activeStep.SetActive(false);
        }

        AudioManager.instance.ItemValidation(nextStep.soundItem,
            new EventCbCookie(nextStep.isIntro, nextStep.sceneTrack));
        // The new active step
        activeStep = nextStep.StepGameObject;
        stayActive = nextStep.stayActive;
    }
}
