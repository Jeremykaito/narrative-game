using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour
{
    public Transform pos;
    private bool up = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (up)
        {
            player.transform.position =
                Vector3.MoveTowards(player.transform.position, pos.position, 2 * Time.deltaTime);
        }

        if (player.transform.position.y > 30)
        {
            UIManager.instance.EndTitle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") return;

        other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.ForwardSpeed = 0;
        other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.BackwardSpeed = 0;
        other.transform.GetComponent<RigidbodyFirstPersonController>().movementSettings.StrafeSpeed = 0;
        other.transform.GetComponent<RigidbodyFirstPersonController>().advancedSettings
            .stickToGroundHelperDistance = 0;
        other.transform.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(Fly());
    }

    private IEnumerator Fly()
    {
        yield return new WaitForSeconds(2f);
        up = true;
        AudioManager.instance.PlayCreditsMusic();
    }
}