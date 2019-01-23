using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour
{
    public Transform pos;
    private bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            GameObject.Find("Player").transform.position = Vector3.MoveTowards(GameObject.Find("Player").transform.position, pos.position, 2 * Time.deltaTime);
        }
        if (GameObject.Find("Player").transform.position.y > 30)
        {
            UIManager.instance.EndTitle();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.ForwardSpeed = 0;
            other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.BackwardSpeed = 0;
            other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.StrafeSpeed = 0;
            other.transform.GetComponent<RigidbodyFirstPersonController>().advancedSettings.stickToGroundHelperDistance = 0;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(fly());
        }
    }

    private IEnumerator fly()
    {
        yield return new WaitForSeconds(2f);
        up = true;
    }
}
