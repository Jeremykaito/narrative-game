using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public float range = 15f;
    public Camera fpsCamera;
    public Transform releasePos;
    private bool pickUpObject = false;
    private RaycastHit target;

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if(pickUpObject == true)
            {
                Release();
            }
            PickUp();
        }
	}

    private void PickUp()
    {

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range))
        {
            InteractiveObject targetObject = target.transform.GetComponent<InteractiveObject>();
            if (targetObject != null)
            {
                if(!targetObject.place)
                {
                    target.transform.GetComponent<Rigidbody>().isKinematic = true;
                    target.transform.position = this.transform.position;
                    target.transform.parent = fpsCamera.transform;
                    target.transform.rotation = new Quaternion(0, 0, 0, 0);
                    pickUpObject = true;
                }
            }
           
        }
    }

    private void Release()
    {
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out target, range))
        {
            target.transform.GetComponent<Rigidbody>().isKinematic = false;
            target.transform.parent = GameObject.Find("Objects").transform;
            target.transform.position = releasePos.position;
            pickUpObject = false;
        }
    }
}
