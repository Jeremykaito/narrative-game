using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private string step;

    public string Step
    {
        get
        {
            return step;
        }

        set
        {
            step = value;
        }
    }

    void Start()
    {
        this.gameObject.layer = 10; // Layer InteractiveObject
    }

   // abstract public void InteractWith();
}
