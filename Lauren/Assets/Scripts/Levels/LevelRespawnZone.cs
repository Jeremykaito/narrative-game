using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelRespawnZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.GetComponent<RigidbodyFirstPersonController>().SetRespawnPoint(other.transform.position);
        }
    }

}
