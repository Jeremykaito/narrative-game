using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectDetector : MonoBehaviour
{
    // Max range to pick up object
    public float range = 2f;
    // Player Main camera
    public Camera fpsCamera;

    // The interactive object
    private RaycastHit target;
    private SwitchObject targetObject;

    private bool nextstep = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Raycast detect an interactive object
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
        {
            UIManager.instance.SetReticule(true);
            if (Input.GetButtonDown("Fire1"))
            {
                targetObject = target.transform.GetComponent<SwitchObject>();
                // If it's an interactive object
                if (targetObject != null)
                {
                    targetObject.Switch();
                    if(!nextstep)
                    {
                        StartCoroutine(LevelManager.instance.StartStep(targetObject.Step));
                        nextstep = true;
                    }
                }
            }
        }
        else
        {
            UIManager.instance.SetReticule(false);
        }
    }
}
