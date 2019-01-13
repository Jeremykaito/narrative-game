using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMaterials : MonoBehaviour {
    [SerializeField]
    private Material fullSceneMaterial;

	// Use this for initialization
	void Start () {
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {

            if(child.GetComponent<Renderer>() != null)
            {

                child.GetComponent<Renderer>().material = fullSceneMaterial;
            }

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
