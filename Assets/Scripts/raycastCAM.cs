using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

[DisallowMultipleComponent]
public class raycastCAM : MonoBehaviour
{
    [Range(0.5f, 100f)] public float range = 1f;

    VolumeEnter volume;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("RaycastVolume").GetComponent<VolumeEnter>();
    }
    void Update()
    {
        //Shoot Raycast only when in trigger zones
        if(volume.isInZone)
        {
            Shoot();
        }        
        
    }


    void Shoot()
    {

        RaycastHit hit;
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);


        //if ray hit's something & mouse is not over some UI element
        if (Physics.Raycast(ray, out hit, range) && !EventSystem.current.IsPointerOverGameObject())
        {
            IsUsable usableObject = hit.transform.GetComponent<IsUsable>();
            if (usableObject != null)
            {
                usableObject.canBeUsedNow = true;
                usableObject.ShowName();
                MasterScript.EnableCrosshairAll();

            }
        }
        else
        {

            MasterScript.setSubText("");
            MasterScript.DisableCrosshairDark();
        }
    }
}

