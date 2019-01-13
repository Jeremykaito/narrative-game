using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectDetector : MonoBehaviour {
    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;
    private MoveObject targetObject;
    private RaycastHit ZoneTarget;

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
                        ReleaseInZone();
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
                    targetObject = target.transform.GetComponent<MoveObject>();
                    // If it's an interactive object
                    if (targetObject != null)
                    {
                            PickUp(target);
                    }
                }
            }
            else
            {
                UIManager.instance.SetReticule(false);
            }
        }
    }

    private void PickUp(RaycastHit target)
    {

        target.transform.GetComponent<Rigidbody>().isKinematic = true;
        target.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        target.transform.position = this.transform.position;
        target.transform.localScale = target.transform.localScale * 2;
        target.transform.parent = fpsCamera.transform;
        target.transform.rotation = new Quaternion(0, 0, 0, 0);
        pickUpObject = true;

    }

    private void Release()
    {
        target.transform.GetComponent<Rigidbody>().isKinematic = false;
        target.transform.gameObject.layer = 10;
        target.transform.parent = GameObject.Find("Objects").transform;

        target.transform.localScale = target.transform.localScale / 2;
        pickUpObject = false;
    }

    private void ReleaseInZone()
    {
        target.transform.gameObject.layer = 10;
        target.transform.parent = GameObject.Find("Objects").transform;

        targetObject.CorrectObjectCloneSwitch();

        StartCoroutine(LevelManager.instance.StartStep(targetObject.Step));
        pickUpObject = false;
    }
}
