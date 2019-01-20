using UnityEngine;

[System.Serializable]
public class Step
{
    public bool isIntro = false;
    public string name;
    public string soundItem;
    public string sceneTrack = null;
    public GameObject StepGameObject;
    public bool stayActive;
    private bool activated;

    public bool Activated
    {
        get
        {
            return activated;
        }

        set
        {
            activated = value;
        }
    }
}
