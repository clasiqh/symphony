using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// use CastRay.Shoot(Camera,layerMask,Range) anywhere, returns detected object.


[DisallowMultipleComponent]
public class CastRay : MonoBehaviour
{

    public static GameObject shootDetectedObject;

    public static void Shoot(Camera ShootCAM, int layerMask, float range)
    {
        RaycastHit hit;
        Ray ray = ShootCAM.ScreenPointToRay(Input.mousePosition);
        

        //if raycast hit any object on Layer
        if (Physics.Raycast(ray, out hit, range, layerMask) && !EventSystem.current.IsPointerOverGameObject())
        {
            shootDetectedObject = hit.transform.gameObject;
        }
        else
        {
            shootDetectedObject = null;
        }

        

    }




}
