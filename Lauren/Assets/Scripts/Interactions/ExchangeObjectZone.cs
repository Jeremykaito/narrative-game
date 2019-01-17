﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeObjectZone : MonoBehaviour
{
    [SerializeField]
    GameObject prefabObject;
    GameObject pickedObject;

    [SerializeField]
    private GameObject correctZone;
    [SerializeField]
    private GameObject correctObjectClone;

    public void ExchangeObject()
    {
        pickedObject = (GameObject)Instantiate(prefabObject);
        pickedObject.GetComponent<MoveObject>().CorrectZone = this.correctZone;
        pickedObject.GetComponent<MoveObject>().CorrectObjectClone = this.correctObjectClone;

        pickedObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        pickedObject.transform.gameObject.layer = 9; // HeldObject : avoid collisions
        pickedObject.transform.position = this.transform.position;
        pickedObject.transform.localScale = pickedObject.transform.localScale * 2;
        pickedObject.transform.parent = Camera.main.transform;
        pickedObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
