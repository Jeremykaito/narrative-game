using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour {

    // Singleton
    public static UIManager instance = null;

    // UI elements
    [SerializeField]
    private Image reticuleOn;
    [SerializeField]
    private Image reticuleOff;
    [SerializeField]
    private RawImage end;

    // Singletion initialization
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

    // Set the reticule black or white
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

    // Hide the reticule when holding an object
    public void HideReticule()
    {
        reticuleOn.enabled = false;
        reticuleOff.enabled = false;
    }

    public void EndTitle()
    {
        end.gameObject.SetActive( true );
        HideReticule();
    }
}
