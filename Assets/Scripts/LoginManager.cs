using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{

    public static GameObject cursorObject; 
    public static GameObject passwordEntered;
    public static GameObject passwordInput;
    public static GameObject passwordInputGlow;
    public static GameObject enterButton;
    public static GameObject enterButtonGlow;
    public static GameObject LoginGroup;
    public static GameObject enterPasswordText;

    public static GameObject objectDetected;



    //only used to make it changable in inspector

    public static string staticPasswordString = "1234";                     // S E T  P A S S W O R D  H E R E
    public static string typedPassword = "1234";



    public void Awake()
    {


        cursorObject = GameObject.Find("Cursor");
        LoginGroup = GameObject.Find("Login");
        passwordEntered = GameObject.Find("Password");
        enterPasswordText = GameObject.Find("enter password text");
        passwordInput = GameObject.Find("Password Input");
        passwordInputGlow = GameObject.Find("Password Input Glow");

        enterButton = GameObject.Find("Enter Button");
        enterButtonGlow = GameObject.Find("Enter Button Glow");


        cursorObject.SetActive(false);
        passwordEntered.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        enterButton.SetActive(true);
        enterButtonGlow.SetActive(false);
        enterPasswordText.SetActive(true);
        LoginGroup.SetActive(true);

        MasterScript.disableScreen(); //disable screen after all references have been set up


    }


    public static void runClickFunction(GameObject clickedObject)
    {
        objectDetected = clickedObject;

        switch (clickedObject.name)
        {



            case "Enter Button":
                enterButtonPressed();
                break;

            case "Password Input":
                inputSelected();
                enterButtonGlow.SetActive(false);
                typedPassword = staticPasswordString;                           // C H A N G E  T H I S
                break;


            default:
                inputDeselected();
                enterButtonGlow.SetActive(false);
                typedPassword = "";
                break;

        }


    }



    public static void inputSelected()
    {


        cursorObject.SetActive(true);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(true);
        passwordEntered.SetActive(true);
        enterPasswordText.SetActive(false);
        enterButtonGlow.SetActive(false);
        MasterScript.toast("type password");

        

    }


    public static void inputDeselected()
    {
        enterButtonGlow.SetActive(false);
        cursorObject.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        passwordEntered.SetActive(true);

    }

    public static void enterButtonPressed()
    {
        cursorObject.SetActive(false);
        passwordInputGlow.SetActive(false);
        enterButtonGlow.SetActive(true);
        passwordEntered.SetActive(false);
        checkpassword(typedPassword);

    }


    public static void checkpassword(string inputPassword)
    {
        if (inputPassword == LoginManager.staticPasswordString)
        {

            MasterScript.toast("Right Password");
            LoginGroup.SetActive(false);

        }
        else
        {
            MasterScript.toast("Wrong Password");
        }
    }


}
