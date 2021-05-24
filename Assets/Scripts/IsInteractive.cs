using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsInteractive : MonoBehaviour
{
    public string displayText;
    public bool canBeUsed = false;
    public bool isInteractedWith = false;
    public bool gravityEnabled = false;  //enable this bool (and on rigidbody ofc) if object needs gravity

    public static Vector3 startingPosition;
    public static Quaternion startingRotation;
    public static bool gravity;



    public static void doStuff()
    {
        IsInteractive interactiveObjectScript = CastRay.detected.GetComponent<IsInteractive>();

        switch (CastRay.detected.tag)
        {
            case "Drawer":
                if (interactiveObjectScript.isInteractedWith == false)
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, 0.35f);
                    interactiveObjectScript.isInteractedWith = true;

                }
                else
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, -0.35f);
                    interactiveObjectScript.isInteractedWith = false;
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
                gravity = interactiveObjectScript.gravityEnabled;
                if (interactiveObjectScript.isInteractedWith == false)
                {
                    
                    Transform camTransform = MasterScript.CAM1.transform;

                    Select(camTransform.position + camTransform.forward * 0.4f, camTransform.position);
                    interactiveObjectScript.isInteractedWith = true;
                }
                else
                {
                    Deselect();
                    interactiveObjectScript.isInteractedWith = false;
                }
                    
                break;


            default:
                Debug.Log("default swtich case");
                break;
        }


    }


    private static void Select(Vector3 focusPosition, Vector3 camPosition)
    {
        //Disable collider on camera so it doesn't collide with object
        MasterScript.CAM1.GetComponent<CapsuleCollider>().isTrigger = true;
        startingPosition = CastRay.detected.transform.position;
        CastRay.detected.transform.position = focusPosition;
        CastRay.detected.transform.LookAt(camPosition);
        MasterScript.interacting = true;
        MasterScript.EnableDOF();

        if (gravity)
        {
            CastRay.detected.GetComponent<Rigidbody>().useGravity = false;
        }


    }


    public static void Deselect()
    {
        //place it back to startingPosition
        MasterScript.interacting = false;
        CastRay.detected.transform.position = startingPosition;
        MasterScript.CAM1.GetComponent<CapsuleCollider>().isTrigger = false;
        MasterScript.DisableDOF();

        if (gravity)
        {
            CastRay.detected.GetComponent<Rigidbody>().useGravity = true;
        }

    }

}
