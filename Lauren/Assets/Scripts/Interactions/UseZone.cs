using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseZone : MonoBehaviour {
    [SerializeField]
    private GameObject useObjectPrefab;

    [SerializeField]
    private GameObject correctZone;
    [SerializeField]
    private GameObject correctObjectClone;

    public GameObject CorrectZone
    {
        get
        {
            return correctZone;
        }

        set
        {
            correctZone = value;
        }
    }

    public GameObject CorrectObjectClone
    {
        get
        {
            return correctObjectClone;
        }

        set
        {
            correctObjectClone = value;
        }
    }

    // Use this for initialization
    void Start () {
        this.gameObject.layer = 10;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetPickedObject()
    {
        return useObjectPrefab;
    }
}
