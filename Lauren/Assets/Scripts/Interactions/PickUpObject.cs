using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    // Max range to pick up object
    public float range = 15f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;

    void Update()
    {
        if (pickUpObject)
        {
            UIManager.instance.HideReticule();
            if (Input.GetButtonDown("Fire1"))
            {
                Release();
            }
        }
        else
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range, 1 << 10))
            {
                UIManager.instance.SetReticule(true);
                if (Input.GetButtonDown("Fire1"))
                {
                    PickUp(target);
                }
            }
            else
            {
                UIManager.instance.SetReticule(false);
            }
        }
    }

    private void PickUp(RaycastHit target)
    {
        InteractiveObject targetObject = target.transform.GetComponent<InteractiveObject>();
        // If it's an interactive object
        if (targetObject != null)
        {
            target.transform.GetComponent<Rigidbody>().isKinematic = true;
            target.transform.gameObject.layer = 9; // HeldObject : avoid collisions
            target.transform.position = this.transform.position;
            target.transform.localScale = target.transform.localScale * 2;
            target.transform.parent = fpsCamera.transform;
            target.transform.rotation = new Quaternion(0, 0, 0, 0);
            pickUpObject = true;
        }
    }

    private void Release()
    {
        target.transform.GetComponent<Rigidbody>().isKinematic = false;
        target.transform.gameObject.layer = 10;
        target.transform.parent = GameObject.Find("Objects").transform;

        target.transform.localScale = target.transform.localScale / 2;
        pickUpObject = false;
    }
}
