using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : InteractiveObject {
    [SerializeField]
    private int nbUse;

    private int nbstep;
    [SerializeField]
    private String[] steps;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        nbstep = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseItem()
    {
        nbUse--;
        nbstep++;
        if (nbUse<=0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public String GetStep()
    {
        return steps[nbstep];
    }
}
