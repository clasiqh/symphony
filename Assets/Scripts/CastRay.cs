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
    public static GameObject temp;

    public static bool objectChange = false;  //true if object detected is different

    public void Awake()
    {
        temp = GameObject.Find("Game Manager");
        detected = GameObject.Find("Game Manager"); 
    }


    public static bool Shoot(Camera ShootCAM, int layerMask, float range)
    {


        Ray ray = ShootCAM.ScreenPointToRay(Input.mousePosition);

        //if raycast hit any object on Layer
        if (Physics.Raycast(ray, out hit, range, layerMask) && !EventSystem.current.IsPointerOverGameObject())
        {
            detected = hit.transform.gameObject;
            hitDistance = Vector3.Distance(detected.transform.position, MasterScript.CAM1.transform.position);
            foundSomething = true;
            if (temp != null)
            {
                if (temp.name != detected.name)
                {
                    objectChange = true;
                    temp = detected;
                }

                else if (temp.name == detected.name)
                    objectChange = false;
            }
            else
            {
                temp = GameObject.Find("Game Manager");
            }

        }
        else
        {
            foundSomething = false;
            objectChange = false;
        }
            

        return foundSomething;

    }

    private void OnDrawGizmos()
    {
        if (foundSomething)
        {
            Gizmos.DrawSphere(hit.point, 0.05f);
            Debug.DrawRay(MasterScript.CAM1.transform.position, MasterScript.CAM1.transform.forward * Vector3.Distance(MasterScript.CAM1.transform.position, hit.point));
        }
    }






}
