using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 abstract public class Interactive : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Look()
    {
        UIManager.instance.SetReticule(true);
        //Surbrillance
    }

    public void StopLooking()
    {
        UIManager.instance.SetReticule(false);
        //Surbrillance
    }

    abstract public void Interact();
}
