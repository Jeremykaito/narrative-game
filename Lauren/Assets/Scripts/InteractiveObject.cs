using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int id;
    public bool place; //a place or a object

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject targetObject = other.transform.GetComponent<InteractiveObject>();
        if (targetObject != null)
        {
            if(targetObject.id == this.id)
            {
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.enabled = false;
            } 
        }
    }
}
