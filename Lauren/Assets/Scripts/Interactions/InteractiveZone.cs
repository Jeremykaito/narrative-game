using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveZone : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private string sound;
    private RaycastHit targetZone;
    private int range = 2;

    [SerializeField]
    private GameObject CorrectObject;

    public void Start()
    {
        this.gameObject.layer = 11;
    }

    private void OnTriggerEnter(Collider other)
    {

        // Raycast detect an interactive zone
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out targetZone, range, 1 << 11))
        {
            InteractiveObject targetObject = other.transform.GetComponent<InteractiveObject>();
            if (targetObject != null)
            {
                if (targetObject.gameObject == CorrectObject)
                {
                    other.transform.GetComponent<Rigidbody>().isKinematic = true;
                    other.transform.position = this.transform.position;
                    other.transform.rotation = new Quaternion(0, 0, 0, 0);
                    other.enabled = false;
                    WinParticles.Play();
                    AudioManager.instance.Play(sound);
                    LevelManager.instance.StartStep(targetObject.Step);
                }
            }
        }
    }
}
