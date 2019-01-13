using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : InteractiveObject {
    [SerializeField]
    private bool state = false;
    [SerializeField]
    private GameObject switchTarget;

    protected override void Start()
    {
        base.Start();
        switchTarget.SetActive(false);
    }

    public void Switch()
    {
        if (state)
        {
            state = false;
        }
        else
        {
            state = true;
        }
        switchTarget.SetActive(state);
    }

}
