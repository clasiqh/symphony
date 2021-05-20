using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsOS : MonoBehaviour
{

    public bool clickable = false;
    public static GameObject detected;
    public string text;

    public static void doThing(GameObject clickedObject)
    {
        detected = clickedObject;
        if (detected.GetComponent<IsOS>().clickable)
        {
            MasterScript.EnableCrosshairAll();
            MasterScript.setSubText(detected.GetComponent<IsOS>().text);
            MasterScript.ShowSubText();
        }

    }
            


}
