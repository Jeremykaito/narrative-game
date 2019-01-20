using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sound;

public class LevelManager : MonoBehaviour {
    public Transform hand;
    public bool isInteracting = false;
    public static LevelManager instance;
    [SerializeField]
    private GameObject activeStep;
    private GameObject lastStep;

    [SerializeField]
    public Step[] steps;

    public string currentZone;
    private bool stayActive;
    [SerializeField]
    private int nbActivatedItems;
    private bool[] activatedItems;

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
        UIManager.instance.SetReticule(false);
        activeStep = null;
        foreach (Step s in steps)
        {
            s.StepGameObject.SetActive(false);
        }
        activatedItems = new bool[nbActivatedItems];
        //Set all zones false
        for (int i = 0;i< activatedItems.Length;i++)
        {
            activatedItems[i] = false;
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

        lastStep = activeStep;
        // The new active step
        activeStep = nextStep.StepGameObject;
        stayActive = nextStep.stayActive;

        yield return null;
    }


    public void ActivateObject(int i)
    {
        activatedItems[i] = true;
        Debug.Log("salut" + i);

        // Level zone 1
        if(activatedItems[0] && !steps[0].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("bureau"));
            steps[0].Activated = true;
        }
        // Lamp
        else if(activatedItems[1] && !steps[1].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("fenetre"));
            steps[1].Activated = true;
        }
        // Phone
        else if (activatedItems[2] && !steps[2].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("fauteuil"));
            steps[2].Activated = true;
        }
        // Match 1
        else if (activatedItems[3] && !steps[3].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("fin_cdf"));
            steps[3].Activated = true;
        }
        // Level zone 2
        else if (activatedItems[4] && !steps[4].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("feu"));
            steps[4].Activated = true;
        }
        // Match 2
        else if (activatedItems[5] && !steps[5].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("marshmallow"));
            steps[5].Activated = true;
        }
        // Marshmallow
        else if (activatedItems[6] && activatedItems[7] && !steps[6].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("guepe1"));
            steps[6].Activated = true;
        }
        // Wasp 1
        else if (activatedItems[8] && !steps[7].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("guepe2"));
            steps[7].Activated = true;
        }
        // Wasp 2
        else if (activatedItems[9] && !steps[8].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("fin_fdc"));
            steps[8].Activated = true;
        }
        // Level zone 3
        else if (activatedItems[10] && !steps[9].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("voiture"));
            steps[9].Activated = true;
        }
        // Car
        else if (activatedItems[11] && !steps[10].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("lauren"));
            steps[10].Activated = true;
        }
        // Road
        else if (activatedItems[12] && !steps[11].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("tommy"));
            steps[11].Activated = true;
        }
        // Deer
        else if (activatedItems[13] && !steps[12].Activated)
        {
            StartCoroutine(LevelManager.instance.StartStep("fin_Rupture"));
            steps[12].Activated = true;
        }

    }
}
