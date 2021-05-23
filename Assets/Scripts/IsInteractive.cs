using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsInteractive : MonoBehaviour
{
    public string displayText;
    public bool canBeUsed = false;
    public bool isInteractedWith = false;

    public static Vector3 startingPosition;
    public static Quaternion startingRotation;



    public static void doStuff()
    {
        IsInteractive isInteractive = CastRay.detected.GetComponent<IsInteractive>();

        switch (CastRay.detected.tag)
        {
            case "Drawer":
                if (isInteractive.isInteractedWith == false)
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, 0.35f);
                    isInteractive.isInteractedWith = true;
                }
                else
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, -0.35f);
                    isInteractive.isInteractedWith = false;
                }
                break;


            /*
            ///Will not work as intended because no collider on monitor when in CAM2
        case "Computer":
            if (isUsed == false)
            {
                MasterScript.EnableCAM2();
                isUsed = true;
            }
            else
            {
                MasterScript.EnableCAM1(); 
                isUsed = false;
            }

            break;
            */

            case "lookable":
                Select(CastRay.detected.transform.position + CastRay.detected.transform.forward*0.5f, CastRay.detected.transform.position);
                Debug.Log("Looking At " + CastRay.detected);
                break;


            default:
                Debug.Log("default swtich case");
                break;
        }


    }


    public static void Select(Vector3 focusPosition, Vector3 target)
    {
        startingPosition = CastRay.detected.transform.position;
        CastRay.detected.transform.position = focusPosition;
        CastRay.detected.transform.LookAt(target);  
    }


    public static void Deselect()
    {
        CastRay.detected.transform.position = startingPosition;
    }

}
