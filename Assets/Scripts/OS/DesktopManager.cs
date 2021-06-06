using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopManager : OSManager
{
    private GameObject computer;
    private GameObject web;
    private GameObject bin;
    private GameObject folder;


    private static GameObject blackComputer;
    private static GameObject blackWeb;
    private static GameObject blackBin;
    private static GameObject blackFolder;

    private void Awake()
    {
        computer = GameObject.Find("computer");
        bin = GameObject.Find("bin");
        folder = GameObject.Find("folder");
        web = GameObject.Find("web");

        blackComputer = GameObject.Find("blackComputer");
        blackBin = GameObject.Find("blackBin");
        blackFolder = GameObject.Find("black_folder");
        blackWeb = GameObject.Find("blackWeb");


        //default states;
        computer.SetActive(true);
        web.SetActive(true);
        folder.SetActive(true);
        bin.SetActive(true);

        disableAllBlack();
        disableDesktop();

    }



    public static void hoverDesktop()
    {
        switch (objectDetected.name)
        {

            case "computer":
                blackComputer.SetActive(true);
                break;

            case "bin":
                blackBin.SetActive(true);
                break;

            case "web":
                blackWeb.SetActive(true);
                break;

            case "folder":
                blackFolder.SetActive(true);
                break;

            default:
                disableAllBlack();
                break;

        }
    }

    public static void clickDesktop()
    {


        switch (objectDetected.name)
        {

            case "computer":
                disableDesktop();
                enableWindow();
                break;

            case "bin":
                Debug.Log("bin clicked");
                break;

            case "web":
                Debug.Log("web clicked");
                break;

            case "folder":
                Debug.Log("folder clicked");
                break;

            default:
                Debug.Log("default clickDesktop");
                break;

        }


    }

    public static void disableAllBlack()
    {
        blackComputer.SetActive(false);
        blackBin.SetActive(false);
        blackWeb.SetActive(false);
        blackFolder.SetActive(false);
    }




}
