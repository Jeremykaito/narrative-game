using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material dissolveMat;
    [SerializeField]
    private float dissolveVal;

    [SerializeField]
    private float disolveFrameRate;
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
        dissolveMat.SetFloat("Vector1_D3B2B4",dissolveVal);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive)
        {
            if(isDisolved)
            {
                if(dissolveVal > 0.06f)
                {
                    dissolveVal -= disolveFrameRate*Time.deltaTime;
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
                if (dissolveVal < 0.94f)
                {
                    dissolveVal += disolveFrameRate*Time.deltaTime;
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
