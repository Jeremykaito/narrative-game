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
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;
        pickedObject.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        pickedObject.transform.position = this.transform.position;
        pickedObject.transform.localScale = pickedObject.transform.localScale * 2;
        pickedObject.transform.parent = fpsCamera.transform;
        pickedObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        this.gameObject.GetComponent<MoveObjectDetector>().PickUpObject = true;
        this.gameObject.GetComponent<MoveObjectDetector>().TargetObject = pickedObject.GetComponent<MoveObject>(); 


    }
}
