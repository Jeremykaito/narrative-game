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

    private void OnTriggerEnter(Collider other)
    {
        // Raycast detect an interactive zone
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out target, range, 1 << 11))
        {
            InteractiveZone targetZone = other.transform.GetComponent<InteractiveZone>();
            if (targetZone != null)
            {
                // Check if the object is in the right zone
                if (targetZone.gameObject == CorrectZone)
                {
                    other.transform.GetComponent<Rigidbody>().isKinematic = true;
                    other.transform.position = this.transform.position;
                    other.transform.rotation = new Quaternion(0, 0, 0, 0);
                    other.enabled = false;

                    WinParticles.Play();
                    AudioManager.instance.Play(sound);
                    LevelManager.instance.StartStep(this.Step);
                }
            }
        }
    }
}
