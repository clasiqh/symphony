using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraScript : MonoBehaviour
{
    public float range = 0.5f;
    [SerializeField] private LayerMask layerMask;


    private void Update()
    {

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

                    MasterScript.EnableCrosshairAll();
                    if (Input.GetMouseButtonDown(0)) //if clicked on the clickable object
                    {
                        LoginManager.runClickFunction(CastRay.detected);
                    }


                }
                else MasterScript.DisableCrosshairDark(); //if the object has IsOS component but isn't clickable



                //code after this would be run while hovering on any 


            }
            else //if detected object doesn't have a IsOS component
            {
                MasterScript.DisableCrosshairDark();
                if (Input.GetMouseButtonDown(0))
                {
                    LoginManager.inputDeselected();
                    LoginManager.enterButtonGlow.SetActive(false);
                    MasterScript.setSubText(" ");
                    MasterScript.HideSubText();
                }
            }







        }
        else MasterScript.DisableCrosshairDark(); //if no object detected by ray
    } //update close

}
