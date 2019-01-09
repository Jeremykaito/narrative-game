using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterZone : MonoBehaviour {
    private bool activated = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !activated)
        {
            AudioManager.instance.Play("CoupDeFil");
            AudioManager.instance.SetVolume("Theme", 0);
            activated = true;
        }
    }
}
