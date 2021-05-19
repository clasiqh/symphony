using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public static GameObject clickedObject;

    public void showClicked()
    {
        Debug.Log(clickedObject.name);
    }
}
