using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactive
{
    [SerializeField]
    private bool state;
    [SerializeField]
    private GameObject switchTarget;
    [SerializeField]
    private bool isActivatedItem;
    [SerializeField]
    private int itemNumber;
    [SerializeField]
    private string soundName = "";
    
    protected void Start()
    {
        switchTarget.SetActive(state);
    }

    public override void Interact()
    {
        state = !state;
        switchTarget.SetActive(state);
        if(isActivatedItem)
        {
            GameManager.instance.ActivateObject(itemNumber);
            isActivatedItem = false;
        }

        if (soundName != "")
        {
            AudioManager.instance.PlaySoundEffect(soundName, gameObject);
        }
    }
}
