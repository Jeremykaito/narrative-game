using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectDetector : MonoBehaviour {
    // Max range to pick up object
    public float rangeArm = 2f;
    public float rangeTofoot = 2f;
    private float range;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;
    private MoveObject targetObject;
    private RaycastHit targetZone;
    [SerializeField]
    private ParticleSystem objectParticles;

    private UseZone useZoneTarget;
    public bool PickUpObject
    {
        get
        {
            return pickUpObject;
        }

        set
        {
            pickUpObject = value;
        }
    }

    public MoveObject TargetObject
    {
        get
        {
            return targetObject;
        }

        set
        {
            targetObject = value;
        }
    }

    void Update()
    {
        if(fpsCamera.transform.localRotation.x > 0.5f)
        {
            range = rangeTofoot;
        }
        else
        {
            range = rangeArm;
        }
        // When the player have an object
        if (pickUpObject)
        {
            UIManager.instance.HideReticule();
            // On click
            if (Input.GetButtonDown("Fire1"))
            {
                // Check the raycasting of an interactive zone
                if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out targetZone, range, 1 << 11))
                {
                    // When the object match with the zone
                    if (targetObject.CheckZone(targetZone.transform.gameObject))
                    {
                        ReleaseInZone();
                        Debug.Log("releaseinzone");
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
                    useZoneTarget = target.transform.GetComponent<UseZone>();
                    // If it's an interactive object
                    if (useZoneTarget != null)
                    {
                        GameObject storedObject = (GameObject)Instantiate(useZoneTarget.GetStoredObject());
                        targetObject = storedObject.GetComponent<MoveObject>();
                        targetObject.CorrectZone = useZoneTarget.CorrectZone;
                        targetObject.CorrectObjectClone = useZoneTarget.CorrectObjectClone;
                        PickUp(targetObject);
                    }
                    else
                    {
                        MoveObject newTargetedObject = target.transform.GetComponent<MoveObject>();
                        // If it's an interactive object
                        if (newTargetedObject != null)
                        {
                            targetObject = newTargetedObject;
                            PickUp(targetObject);
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

    public void PickUp(MoveObject targetO)
    {
        targetO.transform.GetComponent<Rigidbody>().isKinematic = true;
        targetO.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        targetO.transform.position = this.transform.position;
        targetO.transform.localScale = targetO.transform.localScale * 2;
        targetO.transform.parent = fpsCamera.transform;
        targetO.transform.rotation = new Quaternion(0, 0, 0, 0);
        targetO.transform.GetComponent<Rotating>().isRotate = true;
        objectParticles.Play();
        pickUpObject = true;
    }

    private void Release()
    {
        targetObject.transform.GetComponent<Rotating>().isRotate = false;
        targetObject.transform.GetComponent<Rigidbody>().isKinematic = false;
        targetObject.transform.gameObject.layer = 10;
        objectParticles.Stop();
        targetObject.transform.parent = GameObject.Find("Objects").transform;
        targetObject.transform.localScale = targetObject.transform.localScale / 2;
        pickUpObject = false;
    }

    private void ReleaseInZone()
    {
        targetObject.CorrectObjectCloneSwitch();
        targetObject.transform.parent = GameObject.Find("Objects").transform;
        
        ExchangeObjectZone exZone = targetZone.transform.GetComponent<ExchangeObjectZone>();
        if (exZone != null)
        {
            //Debug.Log("is exZone "+ targetZone.transform.gameObject.name);
           // exZone.ExchangeObject(this.transform.position);
            pickUpObject = true;
        }
        else
        {
            pickUpObject = false;
            objectParticles.Stop();
        }

        StartCoroutine(LevelManager.instance.StartStep(targetObject.Step));

    }
}
