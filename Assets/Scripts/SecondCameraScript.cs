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
                IsOS osObject = CastRay.detected.GetComponent<IsOS>();

                //if that OS object is clickable
                if (osObject.clickable)
                {
                    MasterScript.EnableCrosshairAll();
                    if (Input.GetMouseButtonDown(0)) //if clicked on the clickable object
                    {
                        Debug.Log("Clicked: " + osObject.transform.name);
                    }
                }
                else MasterScript.DisableCrosshairDark(); //if the object has IsOS component but isn't clickable

            }
            else MasterScript.DisableCrosshairDark(); //if detected object doesn't have a IsOS component

        }
        else MasterScript.DisableCrosshairDark(); //if no object detected by ray


    }

}
