using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveZone : MonoBehaviour {
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject targetObject = other.transform.GetComponent<InteractiveObject>();
        if (targetObject != null)
        {
            if (targetObject.id == this.id)
            {
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = this.transform.position;
                other.enabled = false;
            }
        }
    }
}
