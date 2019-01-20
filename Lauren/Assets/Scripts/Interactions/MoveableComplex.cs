using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableComplex : Moveable
{
    private Zone zone2;

    public void SetZones(Zone zone1, Zone zone2)
    {
        this.zone1 = zone1;
        this.zone2 = zone2;
    }

    protected override void Update()
    {
        if (this.isInteracting && !timerInteractOn && Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out targetZone, range, 1 << 11))
            {
                Zone zoneClicked = targetZone.transform.GetComponent<Zone>();
                if (zoneClicked.transform.gameObject == zone1.gameObject && !zone1.IsActivated)
                {
                    zone1.Activate();
                    ReleasedInZone();
                }
                else if (zoneClicked.transform.gameObject == zone2.gameObject && !zone2.IsActivated)
                {
                    zone2.Activate();
                    ReleasedInZone();
                }
                else
                {
                    StopInteract();
                }
            }
            else
            {
                StopInteract();
            }
        }
        if (timerStopInteractOn)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                LevelManager.instance.isInteracting = false;
                timer = 0;
                timerStopInteractOn = false;
            }
        }
        else if (timerInteractOn)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                timer = 0;
                timerInteractOn = false;
            }
        }
    }

    protected override void ReleasedInZone()
    {
        if(zone1.IsActivated && zone2.IsActivated)
        {
            this.isInteracting = false;
            LevelManager.instance.isInteracting = false;
            this.gameObject.SetActive(false);
        }
    }

}
