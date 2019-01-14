using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZone : MonoBehaviour
{
    private const string defaultChapterClip = "Palais_mental";
    
    [SerializeField]
    private string firstStep;
    [SerializeField]
    private string chapterClip;

    private bool activated = false;

    // When the player enter the level
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Start the Level theme clip
            AudioManager.instance.PlayMusicTrack(chapterClip);
            // Play the first step only once
            if(!activated)
            {
                // Start the firstStep of the zone
                StartCoroutine(LevelManager.instance.StartStep(firstStep));
                activated = true;
            }
        }
    }
    // When the player exit the level
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            AudioManager.instance.PlayMusicTrack(defaultChapterClip);
        }
    }
}
