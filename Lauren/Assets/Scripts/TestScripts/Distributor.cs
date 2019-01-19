using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : Interactive
{
    [SerializeField] MoveableComplex complexObject;
    [SerializeField] Zone zone1;
    [SerializeField] Zone zone2;

    public override void Interact()
    {
        MoveableComplex distributedObject = Instantiate(complexObject);
        distributedObject.SetZones(zone1, zone2);
        distributedObject.Interact();
    }
}
