using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SwitchCam : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("tab"))
            MasterScript.EnableCAM2();

        if (Input.GetKeyDown("escape"))
        {
            MasterScript.EnableCAM1();
            MasterScript.disableScreen();
        }
            
    }



}
