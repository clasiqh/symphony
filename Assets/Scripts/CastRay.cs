using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// use CastRay.Shoot(Camera,layerMask,Range) anywhere, returns detected object.


[DisallowMultipleComponent]
public class CastRay : MonoBehaviour
{

    public static GameObject detected;

    public void Awake()
    {
        detected = null;
    }


    public static bool Shoot(Camera ShootCAM, int layerMask, float range)
    {
        RaycastHit hit;
        Ray ray = ShootCAM.ScreenPointToRay(Input.mousePosition);
        bool foundSomething;

        //if raycast hit any object on Layer
        if (Physics.Raycast(ray, out hit, range, layerMask) && !EventSystem.current.IsPointerOverGameObject())
        {
            detected = hit.transform.gameObject;
            foundSomething = true;

        }
        else
            foundSomething = false;

        return foundSomething;

    }




}
