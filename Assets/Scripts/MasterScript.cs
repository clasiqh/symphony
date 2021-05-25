using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterScript : MonoBehaviour
{
    public static GameObject crosshair;
    public static GameObject crosshairActive;
    public static GameObject crosshairRed;
    public static GameObject canvas;
    public static GameObject subText;
    public static GameObject pp;
    public static GameObject pp2;
    public static GameObject CAM1;
    public static GameObject CAM2;
    public static GameObject DOF_pp;

    public static bool interacting = false;

    private static GameObject screenUI;


    public void Awake()
    {
        crosshair = GameObject.Find("crosshair");
        crosshairActive = GameObject.Find("crosshairActive");
        crosshairRed = GameObject.Find("crosshairRed");
        canvas = GameObject.Find("Canvas");
        subText = GameObject.Find("subText");
        pp = GameObject.Find("CAM1_PP");
        pp2 = GameObject.Find("CAM2_PP");
        DOF_pp = GameObject.Find("DOF_PP");
        CAM1 = GameObject.Find("CAM1");
        CAM2 = GameObject.Find("CAM2");
        screenUI = GameObject.Find("ScreenUI");

        DisableCrosshairDark();
        EnableCAM1();
        HideSubText();
        DisableDOF();
        


    }



    //CANVAS
    public static void DisableCanvas()
    {
        canvas.SetActive(false);
    }
    public static void EnableCanvas()
    {
        canvas.SetActive(true);
    }


    //SubText
    public static void HideSubText()
    {
        setSubText(" ");
        subText.SetActive(false);
    }
    public static void ShowSubText()
    {
        subText.SetActive(true);
    }
    public static void setSubText(string textToSet)
    {
        subText.GetComponent<TextMeshProUGUI>().SetText(textToSet);
    }


    //SCREEN
    public static void disableScreen()
    {
        screenUI.SetActive(false);
    }
    public static void enableScreen()
    {
        screenUI.SetActive(true);
    }



    //CROSSHAIR
    public static void DisableCrosshairAll()
    {
        crosshair.SetActive(false);
        crosshairActive.SetActive(false);
        crosshairRed.SetActive(false);
    }
    public static void EnableCrosshairAll()
    {
        crosshair.SetActive(true);
        crosshairActive.SetActive(true);
    }

    public static void DisableCrosshairMain()
    {
        crosshair.SetActive(false);

    }
    public static void EnableCrosshairMain()
    {
        crosshair.SetActive(true);
    }
    public static void EnableCrosshairDark()
    {
        crosshairActive.SetActive(true);
    }
    public static void DisableCrosshairDark()
    {
        crosshairActive.SetActive(false);
        crosshairRed.SetActive(false);

    }

    public static void EnableCrosshairRed()
    {
        crosshairRed.SetActive(true);
        crosshairActive.SetActive(false);
    }

    public static void DisableCrosshairRed()
    {
        crosshairRed.SetActive(true);
        crosshairActive.SetActive(false);
    }

    //POST PROCESSING
    public static void EnablePP()
    {
        pp.SetActive(true);
        DOF_pp.SetActive(false);
    }

    public static void DisablePP()
    {
        pp.SetActive(false);
        DOF_pp.SetActive(false);
    }

    public static void EnableDOF()
    {
        DOF_pp.SetActive(true);
    }

    public static void DisableDOF()
    {
        DOF_pp.SetActive(false);
    }



    //CAMERAS

    public static void EnableCAM1()
    {
        CAM1.SetActive(true);
        CAM2.SetActive(false);
        pp.SetActive(true);
        pp2.SetActive(false);
        HideSubText();
        DisableCrosshairDark();

        /// don't disable screen here or refrences will not be set up on LoginManager
        /// using SwitchCam for that


    }
    public static void EnableCAM2()
    {

        CAM1.SetActive(false);
        CAM2.SetActive(true);
        pp.SetActive(false);
        pp2.SetActive(true);
        HideSubText();
        enableScreen();
        DisableCrosshairDark();
    }



    public static void toast(string text)
    {
        setSubText(text);
        ShowSubText();

    }






}
