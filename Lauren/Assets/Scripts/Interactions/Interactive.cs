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
        foreach(MaterialSwitch ms in this.transform.GetComponentsInChildren<MaterialSwitch>())
        {
            if (ms != null)
            {
                ms.HighLightMat();
            }
        }

        
    }

    public void StopLooking()
    {
        UIManager.instance.SetReticule(false); foreach (MaterialSwitch ms in this.transform.GetComponentsInChildren<MaterialSwitch>())
        {
            if (ms != null)
            {
                ms.StandardMat();
            }
        }
    }

    abstract public void Interact();
}
