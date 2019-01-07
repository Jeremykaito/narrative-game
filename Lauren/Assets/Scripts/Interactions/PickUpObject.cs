using UnityEngine;

public class PickUpObject : MonoBehaviour {

    // Max range to pick up object
    public float range = 15f;
    // Player Main camera
    public Camera fpsCamera;
    // State to know is there an object in your hand
    private bool pickUpObject = false;
    // The interactive object
    private RaycastHit target;

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if(pickUpObject == true)
            {
                Release();
            }
            else
            {
                PickUp();
            }
        }
	}

    private void PickUp()
    {
        // If the player look at an object
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range))
        {

            InteractiveObject targetObject = target.transform.GetComponent<InteractiveObject>();
            // If it's an interactive object
            if (targetObject != null)
            {
                target.transform.GetComponent<Rigidbody>().isKinematic = true;
                target.transform.gameObject.layer = 9; // Player layer : avoid collisions between player and holded object
                target.transform.position = this.transform.position;
                target.transform.parent = fpsCamera.transform;
                target.transform.rotation = new Quaternion(0, 0, 0, 0);
                pickUpObject = true;
            } 
        }
    }

    private void Release()
    {
            target.transform.GetComponent<Rigidbody>().isKinematic = false;
            target.transform.gameObject.layer = 0;
            target.transform.parent = GameObject.Find("Objects").transform;
            pickUpObject = false;
    }
}
