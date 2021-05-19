using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsOS : MonoBehaviour
{

    public bool clickable = false;

    private void Update()
    {

        if (Camera_OS.detectedObject != null && Camera_OS.detectedObject.GetComponent<IsOS>().clickable)
        {
            MasterScript.EnableCrosshairAll();
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        else
        {
            MasterScript.DisableCrosshairDark();
        }
    }
            


}
