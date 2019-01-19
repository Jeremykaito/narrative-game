using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y < -5)
        {
            this.transform.position += new Vector3(0, 20, 0);
            this.transform.GetComponent<CustomGravity>().gravityScale = 0;
        }

        if (this.transform.position.y > 10)
        {
            this.transform.position = new Vector3(0, 20, 0);
            this.transform.GetComponent<CustomGravity>().gravityScale = 1;
        }

    }
}
