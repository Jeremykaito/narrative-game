using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material dissolveMat;
    public Material dissolveMatPhares;

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
        dissolveMatPhares.SetFloat("Vector1_D3B2B4", dissolveVal);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive)
        {
            if(isDisolved)
            {
                if(dissolveVal > 0.05f)
                {
                    dissolveVal -= disolveFrameRate*Time.deltaTime;
                    dissolveMat.SetFloat("Vector1_D3B2B4", dissolveVal);

                    dissolveMatPhares.SetFloat("Vector1_D3B2B4", dissolveVal);
                }
                else
                {
                    dissolveMat.SetFloat("Vector1_D3B2B4", 0);
                    isDisolved = false;
                    isActive = false;
                }
            }
            else
            {
                if (dissolveVal < 0.9f)
                {
                    dissolveVal += disolveFrameRate*Time.deltaTime;
                    dissolveMat.SetFloat("Vector1_D3B2B4", dissolveVal);

                    dissolveMatPhares.SetFloat("Vector1_D3B2B4", dissolveVal);
                }
                else
                {
                    dissolveMat.SetFloat("Vector1_D3B2B4", 0.99f);
                    isDisolved = true;
                    isActive = false;

                }
            }
        }
       
    }
}
