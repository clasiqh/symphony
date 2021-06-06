using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : OSManager
{


    public static GameObject windowDefaultText;
    public static GameObject cameraStorage;


    private void Awake()
    {
        windowDefaultText = GameObject.Find("no connected devices");
        cameraStorage = GameObject.Find("CameraStorage");

        if (!MasterScript.cardFound)
        {
            windowDefaultText.SetActive(true);
            cameraStorage.SetActive(false);
        }
        
        disableWindow();
    }


    public static void clickWindow()
    {
        switch (objectDetected.name)
        {
            case "Top_Red":
                disableWindow();
                enableDesktop();
                break;

            default:
                Debug.Log("xxxxx");
                break;
        }

    }
}
