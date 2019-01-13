using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : InteractiveObject {
    [SerializeField]
    private GameObject CorrectZone;
    [SerializeField]
    private GameObject CorrectObjectClone;


    protected override void Start()
    {
        base.Start();
        CorrectObjectClone.SetActive(false);
    }
    public bool CheckZone(GameObject zone)
    {
        return CorrectZone == zone;
    }

    public void CorrectObjectCloneSwitch()
    {
        this.gameObject.SetActive(false);
        CorrectObjectClone.SetActive(true);
    }
}
