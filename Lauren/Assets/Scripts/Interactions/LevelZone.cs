using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZone : MonoBehaviour
{
    private const string defaultChapterClip = "Palais_mental";

    [SerializeField]
    private int itemNumber;
    [SerializeField]
    private string firstStep;
    [SerializeField]
    private string chapterClip;

    private bool isActivatedItem = true;

    // When the player enter the level
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Play the first step only once
            if (isActivatedItem)
            {
                // Start the firstStep of the zone
                //StartCoroutine(LevelManager.instance.StartStep(firstStep));
                LevelManager.instance.ActivateObject(itemNumber);
                isActivatedItem = false;
            }
            else
            {
                // Start the Level theme clip
                AudioManager.instance.SwitchMusicTrack(chapterClip);
            }

            LevelManager.instance.currentZone = chapterClip;
        }
    }
    // When the player exit the level
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            LevelManager.instance.currentZone = defaultChapterClip;
            AudioManager.instance.SwitchMusicTrack(defaultChapterClip);
        }
    }
}
