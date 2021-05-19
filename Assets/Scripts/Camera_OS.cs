using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class Camera_OS : MonoBehaviour
{

    [Range(0.5f, 100f)] public float range = 1f;
    public static GameObject detectedObject;


    private Camera CAM2;
    int osLayer;
    private void Start()
    {
        osLayer = LayerMask.GetMask("OS");
        CAM2 = GameObject.Find("CAM2").GetComponent<Camera>();
    }


    private void Update()
    {
        //shoot raycast every frame (OPTIMISE LATER: shoot only when mouse moves)
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            ShootOS();
        }
    }

    void ShootOS()
    {

        RaycastHit hit;
        Ray ray = CAM2.ScreenPointToRay(Input.mousePosition);


        //if raycast hit any object on "OS" Layer
        if (Physics.Raycast(ray, out hit, range, osLayer))
        {
            detectedObject = hit.transform.gameObject;
        }
        else
        {
            detectedObject = null;
        }


    }




}
