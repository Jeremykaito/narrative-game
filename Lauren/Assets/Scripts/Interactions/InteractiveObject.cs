using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int id;

    public void Start()
    {
        this.gameObject.layer = 10;
    }
}
