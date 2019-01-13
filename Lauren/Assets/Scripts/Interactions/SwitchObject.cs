using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : InteractiveObject {
    [SerializeField]
    private bool state = false;
    [SerializeField]
    private GameObject switchTarget;

    public bool State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }

    public void Switch()
    {
        if(State)
        {
            State = false;
        }
        else
        {
            State = true;
            
        }
        switchTarget.SetActive(State);
    }

}
