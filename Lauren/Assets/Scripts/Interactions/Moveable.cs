﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Interactive
{
    protected bool isInteracting=false;
    protected float timer=0;
    protected float maxTime=0.25f;
    protected bool timerInteractOn = false;
    protected bool timerStopInteractOn = false;
    [SerializeField] protected Zone zone1;
    protected RaycastHit targetZone;
    protected float range = 2.5f;
    public float heldMultiplier = 1.3f;

    protected virtual void Update()
    {
        if (this.isInteracting && !timerInteractOn && Input.GetButtonDown("Fire1") && !GameManager.instance.isCinematic)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out targetZone, range, 1 << 11))
            {

                if (targetZone.transform.gameObject == zone1.gameObject)
                {
                    if (!targetZone.transform.GetComponent<Zone>().IsActivated)
                    {
                        targetZone.transform.GetComponent<Zone>().Activate();
                        ReleasedInZone();
                    }
                    else
                    {
                        StopInteract();
                    }
                }
            }
            else
            {
                StopInteract();
            }
        }
        if (timerStopInteractOn)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                GameManager.instance.isInteracting = false;
                timer = 0;
                timerStopInteractOn = false;
            }
        }
        else if (timerInteractOn)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                timer = 0;
                timerInteractOn = false;
            }
        }
    }

    public override void Interact()
    {
        //this.transform.gameObject.GetComponent<Sha>
        GameManager.instance.isInteracting = true;
        this.isInteracting = true;
        this.transform.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        this.transform.position = GameManager.instance.hand.position;
        this.transform.localScale = this.transform.localScale * heldMultiplier;
        this.transform.parent = Camera.main.transform;
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.GetComponent<Rotating>().isRotate = true;
        timerInteractOn = true;
    }

    protected void StopInteract()
    {
        this.isInteracting = false;
        this.transform.gameObject.layer = 10;
        this.transform.GetComponent<Rotating>().isRotate = false;
        this.transform.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent = GameObject.Find("Objects").transform;
        this.transform.localScale = this.transform.localScale / heldMultiplier;
        timerStopInteractOn = true;
    }

    protected virtual void ReleasedInZone()
    {
        this.isInteracting = false;
        GameManager.instance.isInteracting = false;
        this.gameObject.SetActive(false);
       
    }
}
