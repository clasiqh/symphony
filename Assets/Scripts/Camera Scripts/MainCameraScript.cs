using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MainCameraScript : MonoBehaviour
{

    public float range = 100f;
    public float detectionRange = 1.0f;
    [SerializeField] private LayerMask layerMask;
    private static Camera_WASD_movement wasdScript;



    public void Awake()
    {
        layerMask = LayerMask.GetMask("Default");
        wasdScript = this.GetComponent<Camera_WASD_movement>();
        wasdScript.enabled = true;
        
    }




    public void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            MasterScript.EnableCAM2();
        }

        if(!MasterScript.interacting)
            check();
        else if(MasterScript.interacting)
        {
            if (Input.GetKeyDown("escape"))
            {
                IsInteractive.Deselect();
                MasterScript.setDefaultFOV();
            }
                
        }


    } //update close





    private void check()
    {
        //if something is hit in layer default within range
        if (CastRay.Shoot(this.GetComponent<Camera>(), layerMask, range))
        {

            //if that hit object is Interactive, show subtext & check if can be used.
            if (CastRay.detected.GetComponent<IsInteractive>() != null && CastRay.hitDistance < detectionRange)
            {

                IsInteractive usableObject = CastRay.detected.GetComponent<IsInteractive>();
                MasterScript.setSubText(usableObject.displayText);
                MasterScript.ShowSubText();

                //if that object is usable- turn on crosshair and on pressing E run doStuff().
                if (usableObject.canBeUsed)
                {
                    MasterScript.EnableCrosshairAll();
                    if (Input.GetKeyDown(KeyCode.E))
                        IsInteractive.doStuff();
                }
                else
                    MasterScript.EnableCrosshairRed();
            }

            //and if that hit object is not Interactive.
            else
            {
                MasterScript.setSubText(" ");
                MasterScript.HideSubText();
                MasterScript.DisableCrosshairDark();
            }

        }
        else //if nothing is hit
        {
            MasterScript.setSubText(" ");
            MasterScript.HideSubText();
            MasterScript.DisableCrosshairDark();

        }
    }




}

