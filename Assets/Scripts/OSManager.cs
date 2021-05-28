using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSManager : MonoBehaviour
{

    //For Login Manager
    public static GameObject LoginGroup;

    //For Desktop Manager
    public static GameObject DesktopGroup;


    public static GameObject objectDetected;



    private void Awake()
    {

        //find references
        LoginGroup = GameObject.Find("Login");
        DesktopGroup = GameObject.Find("Desktop");

        //default states
        enableLogin();

    }



    public static void runHoverFunction()
    {
        objectDetected = CastRay.detected;
        switch (objectDetected.tag)
        {
            
            case "Desktop":
                DesktopManager.hoverDesktop();
                break;


            case "Default":
                Debug.Log("default tag");
                break;
        }
    }



    public static void runClickFunction()
    {
        objectDetected = CastRay.detected;
        switch (objectDetected.tag)
        {
            case "Login":
                LoginManager.clickLogin();
                AudioManager.clickSFX();
                break;

            case "Desktop":
                DesktopManager.clickDesktop();
                AudioManager.clickSFX();
                break;


            case "Default":
                Debug.Log("default tag");
                break;
        }
            
    }


    public static void enableLogin()
    {
        LoginGroup.SetActive(true);
    }

    public static void disableLogin()
    {
        LoginGroup.SetActive(false);
    }



    public static void enableDesktop()
    {
        DesktopGroup.SetActive(true);
    }

    public static void disableDesktop()
    {
        DesktopGroup.SetActive(false);
    }


    





}
