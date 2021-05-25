using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginManager : OSManager
{

    public static GameObject cursorObject;
    public static GameObject passwordEntered;
    public static GameObject passwordInput;
    public static GameObject passwordInputGlow;
    public static GameObject enterButton;
    public static GameObject enterButtonGlow;
    public static GameObject enterPasswordText;


    public static string staticPasswordString = "1234";                     // S E T  P A S S W O R D  H E R E
    public static string typedPassword = "123";

    

    private void Awake()
    {

        //find references
        cursorObject = GameObject.Find("Cursor");
        passwordEntered = GameObject.Find("Password");
        enterPasswordText = GameObject.Find("enter password text");
        passwordInput = GameObject.Find("Password Input");
        passwordInputGlow = GameObject.Find("Password Input Glow");
        enterButton = GameObject.Find("Enter Button");
        enterButtonGlow = GameObject.Find("Enter Button Glow");
        


        //default states on game start
        cursorObject.SetActive(false);
        passwordEntered.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        enterButton.SetActive(true);
        enterButtonGlow.SetActive(false);
        enterPasswordText.SetActive(true);


    }


    public static void clickLogin()
    {
        

        switch (objectDetected.name)
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



    private static void inputSelected()
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
        MasterScript.setSubText("");
        MasterScript.HideSubText();
        enterButtonGlow.SetActive(false);

    }

    private static void enterButtonPressed()
    {
        cursorObject.SetActive(false);
        passwordInputGlow.SetActive(false);
        enterButtonGlow.SetActive(true);
        passwordEntered.SetActive(false);
        checkpassword(typedPassword);

    }


    private static void checkpassword(string inputPassword)
    {
        if (inputPassword == LoginManager.staticPasswordString)
        {

            MasterScript.toast("Right Password");
            enableDesktop();
            GameObject.Destroy(LoginGroup);
        }
        else
        {
            MasterScript.toast("Wrong Password");
        }
    }


}
