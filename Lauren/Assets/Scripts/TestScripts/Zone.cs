using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private int nbZone;
    private bool isActivated = false;

    public bool IsActivated
    {
        get
        {
            return isActivated;
        }

        set
        {
            isActivated = value;
        }
    }

    public void Activate()
    {
        if (!isActivated)
        {
            Debug.Log("Zone " + nbZone + " activée");
            //LevelManager.instance.ActivatedZone(nbZone);
            isActivated = true;
        }
    }
}
