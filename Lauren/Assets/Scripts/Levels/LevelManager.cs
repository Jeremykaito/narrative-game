using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sound;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelManager : MonoBehaviour {
    public Transform hand;
    public bool isInteracting = false;
    public static LevelManager instance;

    //Cinematic variables
    public bool isCinematic;

    private GameObject lastStep;
    RigidbodyFirstPersonController player;
    [SerializeField]
    public Step[] steps;

    public string currentZone;
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
        // UI init
        UIManager.instance.SetReticule(false);

        // Steps init
        lastStep = null;
        foreach (Step s in steps)
        {
            if(!s.isIntro)
            {
                s.StepGameObject.SetActive(false);
            }
        }

        // Items init
        activatedItems = new bool[nbActivatedItems];
        // Set all zones false
        for (int i = 0;i< activatedItems.Length;i++)
        {
            activatedItems[i] = false;
        }

        // Cinematic init
        isCinematic = false;
        player = GameObject.Find("Player").transform.GetComponent<RigidbodyFirstPersonController>();
    }

    private IEnumerator StartDissolveAppearFx(Step nextStep)
    {

        if (lastStep != null)
         {
            Debug.Log("disolve");
            GetComponent<Dissolve>().IsActive = true;
            yield return new WaitForSeconds(4f);
            lastStep.SetActive(false);
        }
        if(!nextStep.isIntro)
        {
            nextStep.StepGameObject.SetActive(true);
            GetComponent<Dissolve>().IsActive = true;
        }

        lastStep = nextStep.StepGameObject;
        if(isCinematic)
        {
            CinematicMode(false);
        }

    }
    
    public void OnSpeechEnd(string soundItem, Step nextStep)
    {
            StartCoroutine(StartDissolveAppearFx(nextStep));
    }

    public void StartStep(string name)
    {
        Step nextStep = Array.Find(steps, step =>step.name == name);
        //Trigger cinematic moment
        if(nextStep.isIntro)
        {
            CinematicMode(true);
        }
        AudioManager.instance.ItemValidation(nextStep.soundItem,
            new EventCbCookie(nextStep.soundItem, nextStep, nextStep.isIntro, nextStep.sceneTrack));

    }


    public void ActivateObject(int i)
    {
        activatedItems[i] = true;
        Debug.Log("Item " + i);

        // Level zone 1
        if(activatedItems[0] && !steps[0].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("bureau");
            steps[0].Activated = true;
        }
        // Lamp
        else if(activatedItems[1] && !steps[1].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("fenetre");
            steps[1].Activated = true;
        }
        // Phone
        else if (activatedItems[2] && !steps[2].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("fauteuil");
            steps[2].Activated = true;
        }
        // Match 1
        else if (activatedItems[3] && !steps[3].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("fin_cdf");
            steps[3].Activated = true;
        }
        // Level zone 2
        else if (activatedItems[4] && !steps[4].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("feu");
            steps[4].Activated = true;
        }
        // Match 2
        else if (activatedItems[5] && !steps[5].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("marshmallow");
            steps[5].Activated = true;
        }
        // Marshmallow
        else if (activatedItems[6] && activatedItems[7] && !steps[6].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("guepe1");
            steps[6].Activated = true;
        }
        // Wasp 1
        else if (activatedItems[8] && !steps[7].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("guepe2");
            steps[7].Activated = true;
        }
        // Wasp 2
        else if (activatedItems[9] && !steps[8].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("fin_fdc");
            steps[8].Activated = true;
        }
        // Level zone 3
        else if (activatedItems[10] && !steps[9].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("voiture");
            steps[9].Activated = true;
        }
        // Car
        else if (activatedItems[11] && !steps[10].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("lauren");
            steps[10].Activated = true;
        }
        // Road
        else if (activatedItems[12] && !steps[11].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("tommy");
            steps[11].Activated = true;
        }
        // Deer
        else if (activatedItems[13] && !steps[12].Activated)
        {
            Debug.Log("Step " + i);
            LevelManager.instance.StartStep("fin_Rupture");
            steps[12].Activated = true;
        }
    }

    private void CinematicMode(bool on)
    {
        if(on)
        {
            isCinematic = true;
            UIManager.instance.HideReticule();

        }
        else
        {
            isCinematic = false;
            UIManager.instance.SetReticule(false);
        }
    }
}
