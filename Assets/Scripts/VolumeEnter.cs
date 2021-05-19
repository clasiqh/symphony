using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeEnter : MonoBehaviour
{
    public bool isInZone = false;



    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            isInZone = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        isInZone = false;
    }
  
}
