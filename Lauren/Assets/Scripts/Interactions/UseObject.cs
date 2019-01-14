using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : InteractiveObject {
    [SerializeField]
    private GameObject[] correctZones;
    [SerializeField]
    private GameObject pickedObject;
    [SerializeField]
    private int nbUse = 1;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseItem()
    {
        nbUse--;
        if (nbUse<=0)
        {
            pickedObject.SetActive(false);
        }
    }

    public bool CheckZone(GameObject zone)
    {

      foreach(GameObject correctZone in correctZones)
        {
            if (zone== correctZone)
            {
                return true;
            };
        }
        return false;

    }

    public GameObject GetPickedObject ()
    {
        return pickedObject;
    }
}
