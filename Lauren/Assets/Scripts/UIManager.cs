using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;
    [SerializeField]
    private Image reticuleOn;
    [SerializeField]
    private Image reticuleOff;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetReticule(bool activation)
    {
        if(activation)
        {
            reticuleOn.enabled = true;
            reticuleOff.enabled = false;
        }
        else
        {
            reticuleOn.enabled = false;
            reticuleOff.enabled = true;
        }
    }

    public void HideReticule()
    {
        reticuleOn.enabled = false;
        reticuleOff.enabled = false;
    }
}
