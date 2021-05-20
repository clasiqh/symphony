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
        Debug.Log(detected.name);

    }
            


}
