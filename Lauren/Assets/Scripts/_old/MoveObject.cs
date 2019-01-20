using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : InteractiveObject
{
    [SerializeField]
    private GameObject correctZone;
    [SerializeField]
    private GameObject correctObjectClone;

    public GameObject CorrectZone
    {
        get { return correctZone; }
        set { correctZone = value; }
    }

    public GameObject CorrectObjectClone
    {
        get { return correctObjectClone; }
        set { correctObjectClone = value; }
    }

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
