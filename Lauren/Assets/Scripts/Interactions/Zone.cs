using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private int itemNumber;
    [SerializeField] private GameObject substituteObject;
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
    private void Start()
    {
        substituteObject.SetActive(false);
    }
    public void Activate()
    {
        if (!isActivated)
        {
            Debug.Log("Zone " + " activée");
            LevelManager.instance.ActivateObject(itemNumber);
            isActivated = true;
            substituteObject.SetActive(true);
        }
    }
}
