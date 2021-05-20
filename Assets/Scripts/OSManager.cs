using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OSManager : MonoBehaviour
{

    public static GameObject cursor;
    public static GameObject password;
    public static GameObject passwordInput;
    public static GameObject passwordInputGlow;
    public static GameObject enterButton;
    public static GameObject enterButtonGlow;
    public static GameObject lastClickedObject;



    public void Awake()
    {
        //object references
        cursor = GameObject.Find("cursor");
        password = GameObject.Find("Password");
        passwordInput = GameObject.Find("Password Input");
        passwordInputGlow = GameObject.Find("Password Input Glow");
        enterButton = GameObject.Find("Enter Button");
        enterButtonGlow = GameObject.Find("Enter Button Glow");

        //set default active states
        cursor.SetActive(false);
        password.SetActive(false);
        passwordInput.SetActive(true);
        passwordInputGlow.SetActive(false);
        enterButton.SetActive(true);
        enterButtonGlow.SetActive(false);
    }



    public static void runObjectFunction(GameObject clickedObject)
    {

        lastClickedObject = clickedObject;
        //check what's clicked.
        switch (clickedObject.name)
        {



            case "Enter Button":
                cursor.SetActive(false);
                passwordInputGlow.SetActive(false);
                enterButtonGlow.SetActive(true);

                //check password
                if (password.GetComponent<TextMeshProUGUI>().text == "****")
                    Debug.Log("Right Password");
                else
                    Debug.Log("Wrong Password");

                //keep button glowing for some time to register
                MasterScript.wait(0.5f);
                enterButtonGlow.SetActive(false);
                break;







            case "Password Input":
                inputSelected();
                break;






            default:
                Debug.Log("DEFAULT: " + clickedObject.name);
                break;
        }

    }

    private static void inputSelected()
    {
        while (lastClickedObject == passwordInput)
        {
            cursor.SetActive(true);
            passwordInput.SetActive(true);
            passwordInputGlow.SetActive(true);
            password.SetActive(true);
        }
    }


    private static void inputDeselected()
    {
        
            cursor.SetActive(false);
            passwordInput.SetActive(true);
            passwordInputGlow.SetActive(false);
            password.SetActive(true);

    }


    private bool checkpassword(string inputPassword, string realPassword)
    {
        if (inputPassword == realPassword)
            return true;
        else
            return false;
    }




}
