using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseZone : MonoBehaviour {
    [SerializeField]
    private GameObject useObjectPrefab;
    [SerializeField]
    private GameObject[] correctZones;

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


    public bool CheckZone(GameObject zone)
    {

        foreach (GameObject correctZone in correctZones)
        {
            if (zone == correctZone)
            {
                return true;
            };
        }
        return false;

    }
}
