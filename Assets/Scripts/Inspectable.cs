using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public string text;



    public static void useInspectable()
    {
        switch (CastRay.detected.name)
        {
            case "card_slot":
                InventoryManager.storageIcon.SetActive(true);
                Destroy(GameObject.Find("card_slot").GetComponent<Inspectable>());
                Destroy(GameObject.Find("card_slot").GetComponent<Collider>());
                MasterScript.foundItem = true;
                break;

            default:
                break;
        }
    }
}
