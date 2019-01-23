using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resp : MonoBehaviour
{
    public Transform eresp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.position = eresp.position;
        }
    }
}
