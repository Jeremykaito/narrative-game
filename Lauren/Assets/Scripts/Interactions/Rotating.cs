using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10;
    [SerializeField]
    private float rotationX = 6;
    [SerializeField]
    private float rotationY = 4;
    [SerializeField]
    private float rotationZ = 2;

    public bool isRotate;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRotate)
        {
            transform.Rotate(rotationX * rotationSpeed * Time.deltaTime, rotationY * rotationSpeed * Time.deltaTime, rotationZ * rotationSpeed * Time.deltaTime);
        }

    }
}
