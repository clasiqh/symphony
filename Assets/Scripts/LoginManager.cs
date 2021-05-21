using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{

    public static GameObject cursor;
    public static GameObject passwordEntered;
    public static GameObject passwordInput;
    public static GameObject passwordInputGlow;
    public static GameObject enterButton;
    public static GameObject enterButtonGlow;
    public static GameObject LoginGroup;
    public static GameObject enterPasswordText;

    public static GameObject objectDetected;

    [SerializeField] private string setPassword = "1234";
    public static string staticPasswordString;
    public static string typedPassword;



    public void Awake()
    {


        typedPassword = "";
        staticPasswordString = setPassword;


        //object references
        cursor = GameObject.Find("cursor");
        LoginGroup = GameObject.Find("Login");
        passwordEntered = GameObject.Find("Password");

        enterPasswordText = GameObject.Find("enter password text");
        passwordInput = GameObject.Find("Password Input");
        passwordInputGlow = GameObject.Find("Password Input Glow");

        enterButton = GameObject.Find("Enter Button");
        enterButtonGlow = GameObject.Find("Enter Button Glow");




        //set default active states
        cursor.SetActive(false);
        passwordEntered.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        enterButton.SetActive(true);
        enterButtonGlow.SetActive(false);
        enterPasswordText.SetActive(true);
        LoginGroup.SetActive(true);
    }








    public static void runClickFunction(GameObject clickedObject)
    {
        objectDetected = clickedObject;

        switch (clickedObject.name)
        {



            case "Enter Button":
                enterButtonPressed();
                checkpassword(passwordEntered.name);
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

        cursor.SetActive(true);
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
        cursor.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        passwordEntered.SetActive(true);

    }

    public static void enterButtonPressed()
    {
        cursor.SetActive(false);
        passwordInputGlow.SetActive(false);
        enterButtonGlow.SetActive(true);

    }


    public static void checkpassword(string inputPassword)
    {
        if (inputPassword == LoginManager.staticPasswordString)
        {
            Debug.Log("Right Password");
            MasterScript.toast("Right Password");
            LoginGroup.SetActive(false);

        }
        else
        {
            Debug.Log("Wrong Password");
            MasterScript.toast("Wrong Password");
        }
    }


}
