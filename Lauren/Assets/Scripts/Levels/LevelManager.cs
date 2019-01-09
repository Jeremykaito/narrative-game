﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

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

    public void StartStep(string name)
    {
        Step s = Array.Find(steps, step =>step.name == name);
        if (s == null)
        {
            Debug.LogWarning("Step :" + name + " wasn't found.");
            return;
        }
        s.StepGameObject.SetActive(true);
        AudioManager.instance.Play(s.soundName);
    }

    public void StopStep(string name)
    {
        Step s = Array.Find(steps, step => step.name == name);
        if (s == null)
        {
            Debug.LogWarning("Step :" + name + " wasn't found.");
            return;
        }
        s.StepGameObject.SetActive(false);
    }
}
