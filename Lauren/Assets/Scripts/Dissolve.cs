using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material dissolveMat;
    private float dissolveVal;

    [SerializeField]
    private bool isActive;
    [SerializeField]
    private bool isDisolved;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public bool IsDisolved
    {
        get { return isDisolved; }
        set { isDisolved = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        dissolveVal = dissolveMat.GetFloat("Vector1_D3B2B4");
        dissolveMat.SetFloat("Vector1_D3B2B4",0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive)
        {
            if(isDisolved)
            {
                if(dissolveVal > 0.05)
                {
                    dissolveVal -= 0.01f;
                    dissolveMat.SetFloat("Vector1_D3B2B4", dissolveVal);
                }
                else
                {
                    isDisolved = false;
                    isActive = false;
                }
            }
            else
            {
                if (dissolveVal < 0.95f)
                {
                    dissolveVal += 0.01f;
                    dissolveMat.SetFloat("Vector1_D3B2B4", dissolveVal);
                }
                else
                {
                    isDisolved = true;
                    isActive = false;

                }
            }
        }
       
    }
}
