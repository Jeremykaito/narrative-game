﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveZone : MonoBehaviour {
    public int id;
    [SerializeField]
    private ParticleSystem WinParticles;
    [SerializeField]
    private string sound;

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject targetObject = other.transform.GetComponent<InteractiveObject>();
        if (targetObject != null)
        {
            if (targetObject.id == this.id)
            {
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = this.transform.position;
                other.transform.rotation = new Quaternion(0,0,0,0);
                other.enabled = false;
                WinParticles.Play();
                AudioManager.instance.Play(sound);
            }
        }
    }
}
