using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private string step;
    [SerializeField]
    private int layerO;

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

    protected virtual void Start()
    {
        this.gameObject.layer = layerO; // Layer InteractiveObject
    }

   // abstract public void InteractWith();
}
