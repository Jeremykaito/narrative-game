using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactive
{
    [SerializeField]
    private bool state;

    [SerializeField]
    private GameObject switchTarget;

    protected void Start()
    {
        switchTarget.SetActive(state);
    }

    public override void Interact()
    {
        state = !state;
        switchTarget.SetActive(state);
        //LevelManager.instance.ActivatedStep();
    }
}
