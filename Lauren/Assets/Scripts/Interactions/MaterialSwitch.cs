using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{

    [SerializeField] private Material[] mats;
    private Material standardMat;
    // Start is called before the first frame update
    void Start()
    {
        standardMat = this.transform.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StandardMat()
    {
        this.transform.GetComponent<MeshRenderer>().material = standardMat;
    }

    public void DisolveMat()
    {
        this.transform.GetComponent<MeshRenderer>().material = mats[0];

    }

    public void HighLightMat()
    {
        this.transform.GetComponent<MeshRenderer>().material = mats[1];
    }
}
