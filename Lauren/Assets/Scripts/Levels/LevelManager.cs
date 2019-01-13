using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    private Step activeStep = null;

    [SerializeField]
    public Step[] steps;

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
		foreach(Step s in steps)
        {
            s.StepGameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartStep(string name)
    {
        Step s = Array.Find(steps, step =>step.name == name);

        s.StepGameObject.SetActive(true);
        AudioManager.instance.ItemValidation(s.soundName);
        if (activeStep != null)
        {
            yield return new WaitForSeconds(2f);
            activeStep.StepGameObject.SetActive(false);
        }
        activeStep = s;

    }
}
