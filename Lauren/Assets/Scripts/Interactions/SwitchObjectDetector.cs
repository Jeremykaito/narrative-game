using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectDetector : MonoBehaviour
{
    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;
    private SwitchObject targetObject;
    private RaycastHit ZoneTarget;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Raycast detect an interactive object
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
        {
            UIManager.instance.SetReticule(true);
            if (Input.GetButtonDown("Fire1"))
            {
                targetObject = target.transform.GetComponent<SwitchObject>();
                // If it's an interactive object
                if (targetObject != null)
                {
                    Interact();
                }
            }
        }
        else
        {
            UIManager.instance.SetReticule(false);
        }
    }

    private void Interact()
    {
        //Changer l'état de l'objet
        StartCoroutine(LevelManager.instance.StartStep(targetObject.Step));
    }


}
