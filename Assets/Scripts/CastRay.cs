using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// use CastRay.Shoot(Camera,layerMask,Range) anywhere, returns detected object.


[DisallowMultipleComponent]
public class CastRay : MonoBehaviour
{

    public static GameObject detected;
    public static float hitDistance;
    public static bool foundSomething;
    public static RaycastHit hit;


    public void Awake()
    {
        detected = null; 
    }


    public static bool Shoot(Camera ShootCAM, int layerMask, float range)
    {


        Ray ray = ShootCAM.ScreenPointToRay(Input.mousePosition);

        //if raycast hit any object on Layer
        if (Physics.Raycast(ray, out hit, range, layerMask) && !EventSystem.current.IsPointerOverGameObject())
        {
            detected = hit.transform.gameObject;
            hitDistance = Vector3.Distance(detected.transform.position, hit.point);
            foundSomething = true;

        }
        else
            foundSomething = false;

        return foundSomething;

    }

    private void OnDrawGizmos()
    {
        if (foundSomething)
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            Debug.DrawRay(MasterScript.CAM1.transform.position, MasterScript.CAM1.transform.forward * Vector3.Distance(MasterScript.CAM1.transform.position, hit.point));
        }
    }






}
