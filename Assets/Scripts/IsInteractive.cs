using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsInteractive : MonoBehaviour
{
    public string displayText;
    public bool canBeUsed = false; //if something should happen on pressing E or not.
    public bool isInteractedWith = false; //mainly used to store drawer's open/closed state. [NOTE: non static]

    public static Vector3 startingPosition;
    public static Quaternion startingRotation;





    //runs when E is pressed on Interactive Object
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
                    AudioManager.DrawerOpenSFX();

                }
                else
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, -0.35f);
                    interactiveObjectScript.isInteractedWith = false;
                    AudioManager.DrawerCloseSFX();
                }
                break;


            case "Computer":
                MasterScript.EnableCAM2();
                break;


            case "lookable":

                //if the object isn't already interactedWith && not currently inspecting anything else
                if (!interactiveObjectScript.isInteractedWith && !MasterScript.inspecting)
                {
                    Transform camTransform = MasterScript.CAM1.transform;
                    Select(camTransform.position + camTransform.forward * 0.4f, camTransform.position);
                }
                break;


            default:
                Debug.Log("default interactive object");
                break;

        } // switch close


    } //doStuff() close


    public static void Select(Vector3 focusPosition, Vector3 camPosition)
    {
        MasterScript.selectedObject = CastRay.detected;
        //Disable collider on camera so it doesn't collide with object
        MasterScript.CAM1.GetComponent<CapsuleCollider>().isTrigger = true;
        startingPosition = CastRay.detected.transform.position;
        MasterScript.selectedObject.transform.position = focusPosition;
        MasterScript.selectedObject.transform.LookAt(camPosition);
        MasterScript.EnableDOF();
        MasterScript.selectedObject.GetComponent<IsInteractive>().isInteractedWith = true;
        MasterScript.selectedObject.GetComponent<Collider>().enabled = false;
        Destroy(MasterScript.selectedObject.GetComponent<Rigidbody>());
        MasterScript.inactive();
        MasterScript.inspecting = true;


        if(MasterScript.selectedObject == InventoryManager.inventory)
        {
            MasterScript.DisableDOF();
        }
    }


    public static void Deselect()
    {
        //place it back to startingPosition
        MasterScript.inspecting = false;
        MasterScript.selectedObject.transform.position = startingPosition;
        MasterScript.selectedObject.GetComponent<IsInteractive>().isInteractedWith = false;
        MasterScript.selectedObject.GetComponent<Collider>().enabled = true;
        MasterScript.selectedObject.AddComponent<Rigidbody>();

        MasterScript.inactive();
        MasterScript.CAM1.GetComponent<Collider>().isTrigger = false;
        MasterScript.DisableDOF();
    }

}
