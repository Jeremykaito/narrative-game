﻿using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;
    private InteractiveObject targetObject;
    private RaycastHit ZoneTarget;

    void Update()
    {
        if (pickUpObject)
        {
            UIManager.instance.HideReticule();
            if (Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out ZoneTarget, range, 1 << 11))
                {
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
                    targetObject = target.transform.GetComponent<InteractiveObject>();
                    // If it's an interactive object
                    if (targetObject != null)
                    {
                        if (targetObject.moveable)
                        {
                            PickUp(target);
                        }
                        else
                        {
                            Interact(targetObject);
                        }
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
        target.transform.localScale = target.transform.localScale / 2;
        target.transform.position = this.transform.position;
        target.transform.rotation = new Quaternion(0, 0, 0, 0);
        target.transform.gameObject.SetActive(false);

        LevelManager.instance.StartStep(targetObject.Step);
        pickUpObject = false;
    }

    private void Interact(InteractiveObject target)
    {
        //Changer l'état de l'objet
        LevelManager.instance.StartStep(target.Step);
    }
}
