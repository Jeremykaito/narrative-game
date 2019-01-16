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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX * rotationSpeed * Time.deltaTime, rotationY * rotationSpeed * Time.deltaTime, rotationZ * rotationSpeed * Time.deltaTime);

    }
}
