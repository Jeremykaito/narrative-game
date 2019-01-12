using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private RaycastHit target;
    private int range = 2;

    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private GameObject CorrectZone;
    [SerializeField]
    private string step;


    [SerializeField]
    private string sound;
    public bool moveable;

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

    public void Start()
    {
        this.gameObject.layer = 10; // Layer InteractiveObject
    }
}
