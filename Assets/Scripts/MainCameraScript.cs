using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MainCameraScript : MonoBehaviour
{

    public float range = 100f;
    [SerializeField] private LayerMask layerMask;
    


    public void Awake()
    {
        
    }
    public void Update()
    {



        //if something is hit
        if (CastRay.Shoot(GameObject.Find("CAM1").GetComponent<Camera>(), layerMask, range))
        {



            //and if that hit object is Interactive.
            if (CastRay.detected.GetComponent<IsInteractive>() != null && CastRay.hitDistance<1.0f)
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

