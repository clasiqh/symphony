using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SwitchCam : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("tab"))
            switchToCAM2();

        if (Input.GetKeyDown("escape"))
            switchToCAM1();
    }

    //MAIN CAM
    public static void switchToCAM1()
    {
        MasterScript.EnableCAM1();
    }

    public static void switchToCAM2()
    {
        MasterScript.EnableCAM2();
    }

    




}
