using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material disolveMat;
    public bool isActive;
    private float disolveVal;

    // Start is called before the first frame update
    void Start()
    {
        disolveVal = disolveMat.GetFloat("Vector1_D3B2B4");
        disolveMat.SetFloat("Vector1_D3B2B4",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(disolveVal < 1 && isActive)
        {
            Debug.Log("test" + disolveVal);
            disolveVal += 0.01f;
            disolveMat.SetFloat("Vector1_D3B2B4", disolveVal);
        }
    }
}
