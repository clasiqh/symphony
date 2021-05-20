using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MainCameraScript : MonoBehaviour
{

    private VolumeEnter volume;
    public float range = 0.8f;
    [SerializeField] private LayerMask layerMask;

    public void Awake()
    {
        volume = GameObject.Find("Raycast Volume").GetComponent<VolumeEnter>();
    }
    public void Update()
    {
        //Shoot Raycast only when in trigger zones
        if (volume.isInZone)
        {
            CastRay.Shoot(GameObject.Find("CAM1").GetComponent<Camera>(), layerMask, range); //(OPTIMISE LATER: shoot only when mouse moves)
            Debug.Log(CastRay.shootDetectedObject.name);

            /*

            if (detected.GetComponent<IsUsable>() != null)
            {
                usableObject = detected.GetComponent<IsUsable>();
                MasterScript.setSubText(usableObject.displayText);
                MasterScript.EnableCrosshairAll();

            }
            
            //if object that was detected isn't usable
            else
            {
                MasterScript.setSubText("");
                MasterScript.DisableCrosshairDark();
                detected = null;
            }
            */
        }

    }
}

