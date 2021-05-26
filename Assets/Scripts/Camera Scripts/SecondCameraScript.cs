using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraScript : MonoBehaviour
{
    public float range = 0.5f;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("OS");
    }


    private void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            MasterScript.EnableCAM1();
        }

        //check for object on layer OS
        if (CastRay.Shoot(this.GetComponent<Camera>(), layerMask, range)) //(OPTIMISE LATER: shoot only when mouse moves)
        {

            //if the detected Object has IsOS Component
            if (CastRay.detected.GetComponent<IsOS>() != null)
            {

                //if that OS object is clickable
                if (CastRay.detected.GetComponent<IsOS>().clickable)
                {

                    //CODE HERE WILL RUN IF HOVERING ON CLICKABLE OBJECT
                    OSManager.runHoverFunction();
                    MasterScript.EnableCrosshairAll();
                    MasterScript.toast(CastRay.detected.GetComponent<IsOS>().text);
                    if (Input.GetMouseButtonDown(0)) //if clicked on the clickable object
                    {
                        OSManager.runClickFunction();
                    }


                }
                else //if the object has IsOS component but isn't clickable
                {
                    MasterScript.DisableCrosshairDark();
                    MasterScript.HideSubText();
                    DesktopManager.disableAllBlack();
                }



            }
            else //if detected object doesn't have a IsOS component
            {
                MasterScript.DisableCrosshairDark();
                MasterScript.HideSubText();
                DesktopManager.disableAllBlack();
                if (Input.GetMouseButtonDown(0))
                {
                    LoginManager.inputDeselected();
                }
            }







        }
        else //if no object detected by ray
        {
            MasterScript.DisableCrosshairDark();
            MasterScript.HideSubText();
            DesktopManager.disableAllBlack();
        }
         
    } //update close

}
