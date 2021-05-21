using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MainCameraScript : MonoBehaviour
{

    private VolumeEnter volume;
    public float range = 0.8f;
    [SerializeField] private LayerMask layerMask;

    public void Awake()
    {
        volume = GameObject.Find("Raycast Volume").GetComponent<VolumeEnter>();
    }
    public void Update()
    {
        //Shoot Raycast only when in trigger zones
        if (volume.isInZone)
        {

            //if something is hit in trigger zone
            if(CastRay.Shoot(GameObject.Find("CAM1").GetComponent<Camera>(), layerMask, range))
            {

                //and if that hit object is Interactive.
                if (CastRay.detected.GetComponent<IsInteractive>() != null)
                {

                    IsInteractive usableObject = CastRay.detected.GetComponent<IsInteractive>();
                    MasterScript.setSubText(usableObject.displayText);
                    MasterScript.ShowSubText();

                    //if that object is usable
                    if (usableObject.canBeUsed)
                    {
                        MasterScript.EnableCrosshairAll();
                        if(Input.GetKeyDown(KeyCode.E))
                        IsInteractive.doStuff();
                    }
                }

                //and if that hit object is not Interactive.
                else
                {
                    MasterScript.setSubText(" ");
                    MasterScript.HideSubText();
                    MasterScript.DisableCrosshairDark();
                }

            }
            else
            {
                MasterScript.setSubText(" ");
                MasterScript.HideSubText();
                MasterScript.DisableCrosshairDark();

            }

            //if object that was detected is usable
            

        }


    }
}

