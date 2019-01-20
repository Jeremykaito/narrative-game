using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem objectParticles;
    // Max range to pick up object
    public float rangeArm = 2f;
    public float rangeTofoot = 2f;
    private float range;
    // Player Main camera
    public Camera fpsCamera;

    // The interactive object
    private RaycastHit target;
    private Interactive targetObject;
    private RaycastHit targetZone;

    void Update()
    {
        if (fpsCamera.transform.localRotation.x > 0.4f)
        {
            range = rangeTofoot;
        }
        else
        {
            range = rangeArm;
        }
        
        // Raycast detect an interactive object
        if (!LevelManager.instance.isInteracting && Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
        {
            targetObject = target.transform.GetComponent<Interactive>();
            targetObject.Look();
            if (Input.GetButtonDown("Fire1"))
            {
                targetObject.Interact();
            }
        }
        else if(targetObject!=null)
        {
            targetObject.StopLooking();
        }

        if(LevelManager.instance.isInteracting)
        {
            objectParticles.gameObject.SetActive(true);
            objectParticles.Play();
        }
        else
        {
            objectParticles.Stop();
            objectParticles.gameObject.SetActive(false);
        }
    }
}
