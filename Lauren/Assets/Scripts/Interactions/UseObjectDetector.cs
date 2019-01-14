using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObjectDetector : MonoBehaviour {
    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;
    private UseObject targetObject;
    private RaycastHit ZoneTarget;

    private GameObject pickedObject;

    void Update()
    {
        // When the player have an object
        if (pickUpObject)
        {
            UIManager.instance.HideReticule();
            // On click
            if (Input.GetButtonDown("Fire1"))
            {
                // Check the raycasting of an interactive zone
                if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out ZoneTarget, range, 1 << 11))
                {
                    // When the object match with the zone
                    if (targetObject.CheckZone(ZoneTarget.transform.gameObject))
                    {
                        targetObject.UseItem();
                    }
                    else
                    {
                        Release();
                    }
                }
                else
                {
                    Release();
                }
            }
        }
        else
        {
            // Raycast detect an interactive object
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
            {
                UIManager.instance.SetReticule(true);
                if (Input.GetButtonDown("Fire1"))
                {
                    targetObject = target.transform.GetComponent<UseObject>();
                    // If it's an interactive object
                    if (targetObject != null)
                    {
                        PickOne();
                    }
                }
            }
            else
            {
                UIManager.instance.SetReticule(false);
            }
        }
    }


    private void PickOne()
    {
        pickedObject = targetObject.GetPickedObject();
        pickedObject = (GameObject)Instantiate(pickedObject);
        pickedObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        pickedObject.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        pickedObject.transform.position = this.transform.position;
        pickedObject.transform.localScale = pickedObject.transform.localScale /20;
        pickedObject.transform.parent = fpsCamera.transform;
        pickedObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        pickUpObject = true;
    }

    private void Release()
    {
        pickedObject.transform.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.transform.gameObject.layer = 10;
        pickedObject.transform.parent = GameObject.Find("Objects").transform;

        pickedObject.transform.localScale = target.transform.localScale / 10;
        pickUpObject = false;
    }
}
