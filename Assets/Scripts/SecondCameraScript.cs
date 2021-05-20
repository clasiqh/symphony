using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraScript : MonoBehaviour
{
    public float range = 0.5f;
    [SerializeField] private LayerMask layerMask;


    private void Update()
    {
        CastRay.Shoot(this.GetComponent<Camera>(), layerMask, range); //(OPTIMISE LATER: shoot only when mouse moves)
        Debug.Log(CastRay.shootDetectedObject.name);

        /*
        osObject = detectedByCAM2.GetComponent<IsOS>();
        if (osObject != null && osObject.clickable == true)
        {
            MasterScript.EnableCrosshairAll();
            if (Input.GetMouseButtonDown(0))
            {
                GameObject clickedObject = detectedByCAM2;
                IsOS.doThing(clickedObject);
            }

        }
        else
            MasterScript.DisableCrosshairDark();
        */

    }

}
