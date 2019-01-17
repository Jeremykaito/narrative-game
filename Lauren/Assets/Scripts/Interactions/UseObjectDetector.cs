using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObjectDetector : MonoBehaviour
{
    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;
    // The interactive object
    private RaycastHit target;
    private UseZone useZoneTarget;
    private GameObject pickedObject;

    void Update()
    {
        // Raycast detect an interactive object
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
        {
            UIManager.instance.SetReticule(true);
            if (Input.GetButtonDown("Fire1"))
            {
                useZoneTarget = target.transform.GetComponent<UseZone>();
                // If it's an interactive object
                if (useZoneTarget != null)
                {
                    PickOneObject();
                }
            }
        }
        else
        {
            UIManager.instance.SetReticule(false);
        }

    }

    private void PickOneObject()
    {
        pickedObject = (GameObject)Instantiate(useZoneTarget.GetPickedObject());
        pickedObject.GetComponent<MoveObject>().CorrectZone = useZoneTarget.CorrectZone;
        pickedObject.GetComponent<MoveObject>().CorrectObjectClone = useZoneTarget.CorrectObjectClone;

        this.gameObject.GetComponent<MoveObjectDetector>().PickUp(pickedObject.GetComponent<MoveObject>());


    }
}
