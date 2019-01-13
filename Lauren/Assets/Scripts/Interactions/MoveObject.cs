using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : InteractiveObject {
    [SerializeField]
    private GameObject CorrectZone;

    public bool CheckZone(GameObject zone)
    {
        return CorrectZone == zone;
    }
}
