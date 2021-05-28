using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MainCameraScript : MonoBehaviour
{

    public float shootRange = 1.4f;
    [SerializeField] private LayerMask defaultLayer;
    [SerializeField] private LayerMask inspectLayer;
    private static Camera_WASD_movement wasdScript;
    public static float rotSpeed = 120f;
    public static float zoomSpeed = 300.0f;


    public void Awake()
    {
        defaultLayer = LayerMask.GetMask("Default");
        inspectLayer = LayerMask.GetMask("Inspect");
        wasdScript = this.GetComponent<Camera_WASD_movement>();
        wasdScript.enabled = true;

    }


    public void Update()
    {

        if (!MasterScript.inspecting)
            defaultMode();

        else if (MasterScript.inspecting)
        {
            inspectMode();
            if (Input.GetKeyDown("escape"))
            {
                IsInteractive.Deselect();
                MasterScript.setDefaultFOV();
            }
        }

    } //update close




    private void defaultMode()
    {
        //if something is hit in layer default within range
        if (CastRay.Shoot(this.GetComponent<Camera>(), defaultLayer, shootRange))
        {
            //if that hit object is Interactive, show subtext & check if can be used.
            if (CastRay.detected.GetComponent<IsInteractive>() != null)
            {
                IsInteractive usableObject = CastRay.detected.GetComponent<IsInteractive>();
                MasterScript.toast(usableObject.displayText);

                //if that object is usable- turn on crosshair and on pressing E run doStuff().
                if (usableObject.canBeUsed)
                {
                    MasterScript.EnableCrosshairAll();
                    if (Input.GetKeyDown(KeyCode.E))
                        IsInteractive.doStuff();
                }
                else
                    MasterScript.EnableCrosshairRed();
            }

            else //and if that hit object is not Interactive.
                MasterScript.inactive();
        } //shoot close

        else //if nothing is hit
            MasterScript.inactive();

    }


    private void inspectMode()
    {
        if (Input.GetMouseButton(0))
            onMouseDrag();

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            MasterScript.CAM1.GetComponent<Camera>().fieldOfView -= zoomSpeed * Time.deltaTime;
        }
        else if ((Input.GetAxis("Mouse ScrollWheel") < 0f))
        {
            MasterScript.CAM1.GetComponent<Camera>().fieldOfView += zoomSpeed * Time.deltaTime;
        }



        if (CastRay.Shoot(this.GetComponent<Camera>(), inspectLayer, shootRange))
        {

            if (CastRay.detected.GetComponent<Inspectable>() != null)
            {
                MasterScript.EnableCrosshairAll();
                Inspectable inspectableScript = CastRay.detected.GetComponent<Inspectable>();
                MasterScript.toast(inspectableScript.text);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Inspectable.useInspectable();
                }

            }
            else
                MasterScript.inactive();

        }// shoot close

        else //if nothing is hit
            MasterScript.inactive();


    }


    private static void onMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        MasterScript.selectedObject.transform.Rotate(Vector3.up, -rotX);
        MasterScript.selectedObject.transform.Rotate(Vector3.right, -rotY);

    }


} // class close

