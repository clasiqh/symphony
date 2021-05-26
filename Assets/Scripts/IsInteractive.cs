using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IsInteractive : MonoBehaviour
{
    public string displayText;
    public bool canBeUsed = false; //if something should happen on pressing E or not.
    public bool isInteractedWith = false; //mainly used to store drawer's open/closed state. [NOTE: non static]
    public bool gravityEnabled = false;  //enable this bool (and on rigidbody ofc) if object needs gravity [NOTE: non static]

    public static Vector3 startingPosition;
    public static Quaternion startingRotation;
    public static bool gravity; //[NOTE: static]

    public float rotSpeed = 0.5f;
    public float zoomSpeed = 300.0f;



    public void Update()
    {

        if (MasterScript.interacting)
        {
            if (Input.GetMouseButton(0))
                onMouseDrag();

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                MasterScript.CAM1.GetComponent<Camera>().fieldOfView -= zoomSpeed * Time.deltaTime;
            }
            else if((Input.GetAxis("Mouse ScrollWheel") < 0f))
            {
                MasterScript.CAM1.GetComponent<Camera>().fieldOfView += zoomSpeed * Time.deltaTime;
            }

        }
            

    }

    void onMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
            CastRay.detected.transform.Rotate(Vector3.up, -rotX);
        else if(Mathf.Abs(rotY) > Mathf.Abs(rotX))
        CastRay.detected.transform.Rotate(Vector3.right, -rotY);

    }





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

                }
                else
                {
                    CastRay.detected.transform.Translate(0.0f, 0f, -0.35f);
                    interactiveObjectScript.isInteractedWith = false;
                }
                break;




        case "Computer":
                MasterScript.EnableCAM2();
                break;


            case "lookable":

                //if the object isn't already interactedWith && not currently interacting with anything else
                if (!interactiveObjectScript.isInteractedWith && !MasterScript.interacting)
                {
                    gravity = interactiveObjectScript.gravityEnabled;
                    Transform camTransform = MasterScript.CAM1.transform;
                    Select(camTransform.position + camTransform.forward * 0.4f, camTransform.position);
                }
                else if(interactiveObjectScript.isInteractedWith && MasterScript.interacting)
                {
                    Deselect();  
                }
                    
                break;


            default:
                Debug.Log("default interactive object");
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
        CastRay.detected.GetComponent<IsInteractive>().isInteractedWith = true;
        if (gravity)
        {
            CastRay.detected.GetComponent<Rigidbody>().useGravity = false; //disable gravity so the object doesn't fall down
        }


        MasterScript.DisableCrosshairDark();
        MasterScript.HideSubText();


    }


    public static void Deselect()
    {
        //place it back to startingPosition
        MasterScript.interacting = false;
        CastRay.detected.transform.position = startingPosition;
        MasterScript.CAM1.GetComponent<CapsuleCollider>().isTrigger = false;
        MasterScript.DisableDOF();
        CastRay.detected.GetComponent<IsInteractive>().isInteractedWith = false;

        if (gravity)
        {
            CastRay.detected.GetComponent<Rigidbody>().useGravity = true;
            gravity = false;
        }



    }

}
