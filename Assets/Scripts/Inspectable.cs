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
                MasterScript.cardFound = true;
                WindowManager.cameraStorage.SetActive(true);
                WindowManager.windowDefaultText.SetActive(false);
                MasterScript.showMessage("Item Found: Memeory Card");
                
                break;


            case "passwordLocation":
                InventoryManager.passwordIcon.SetActive(true);
                Destroy(GameObject.Find("passwordLocation").GetComponent<Inspectable>());
                Destroy(GameObject.Find("passwordLocation").GetComponent<Collider>());
                MasterScript.passwordFound = true;
                MasterScript.showMessage("Item Found: Computer Password");
                break;

            default:
                break;
        }
    }
}
