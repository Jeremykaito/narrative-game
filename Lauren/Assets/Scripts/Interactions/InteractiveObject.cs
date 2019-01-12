using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private GameObject CorrectZone;
    [SerializeField]
    private string step;

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

    public bool CheckZone(GameObject zone) 
    {
        return CorrectZone == zone;
    }
}
