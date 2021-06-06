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
        
        enableLogin();

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
                break;


            default:
                inputDeselected();
                enterButtonGlow.SetActive(false);
                break;

        }


    }



    private static void inputSelected()
    {


        cursorObject.SetActive(true);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(true);
        enterPasswordText.SetActive(false);
        enterButtonGlow.SetActive(false);

        if (MasterScript.passwordFound)
        {
            passwordEntered.SetActive(true);
            passwordInput.GetComponent<IsOS>().text = "Password Entered";
        }
        else
        {
            passwordEntered.SetActive(false);
            passwordInput.GetComponent<IsOS>().text = "You don't have the password.";
        }




    }


    public static void inputDeselected()
    {
        enterButtonGlow.SetActive(false);
        cursorObject.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        MasterScript.HideSubText();
        enterButtonGlow.SetActive(false);

    }

    private static void enterButtonPressed()
    {


        if (!MasterScript.passwordFound)
            enterButton.GetComponent<IsOS>().text = "Can't Login Without Password";

        else
        {
            enterButton.GetComponent<IsOS>().text = "Press to Login";
            MasterScript.EnableCrosshairAll();
        }
        cursorObject.SetActive(false);
        passwordInputGlow.SetActive(false);
        enterButtonGlow.SetActive(true);
        passwordEntered.SetActive(false);
        checkpassword();

    }


    private static void checkpassword()
    {

        if (MasterScript.passwordFound)
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
