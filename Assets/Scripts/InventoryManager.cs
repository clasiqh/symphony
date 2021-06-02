using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static GameObject inventory;

    public static GameObject cropIcon;
    public static GameObject noteIcon;
    public static GameObject musicIcon;
    public static GameObject passwordIcon;
    public static GameObject settingsIcon;
    public static GameObject keyIcon;
    public static GameObject storageIcon;
    public static GameObject videoIcon;

    public static bool inventoryActive = false;



    private void Awake()
    {
        inventory = GameObject.Find("Inventory");

        cropIcon = GameObject.Find("crop_icon");
        noteIcon = GameObject.Find("note_icon");
        musicIcon = GameObject.Find("music_note_icon");
        passwordIcon = GameObject.Find("password_icon");
        keyIcon = GameObject.Find("key_icon");
        storageIcon = GameObject.Find("storage_icon");
        videoIcon = GameObject.Find("videocam_icon");
        settingsIcon = GameObject.Find("settings_icon");


        inventory.SetActive(false);

        cropIcon.SetActive(false);
        noteIcon.SetActive(false);
        musicIcon.SetActive(false);
        passwordIcon.SetActive(false);
        keyIcon.SetActive(false);
        storageIcon.SetActive(false);
        videoIcon.SetActive(false);
        settingsIcon.SetActive(false);


    }


    private void Update()
    {
        if (!inventoryActive)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                Cursor.lockState = CursorLockMode.Confined;
                inventory.SetActive(true);
                inventoryActive = true;
                MasterScript.CAM1.GetComponent<Camera_WASD_movement>().enabled = false;
                MasterScript.EnableDOF();

            }
        }
        else if (inventoryActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventory.SetActive(false);
                inventoryActive = false;
                MasterScript.DisableDOF();
                MasterScript.CAM1.GetComponent<Camera_WASD_movement>().enabled = true;
            }
        }

        /*
        if (inventory.GetComponent<Rigidbody>() != null)
        {
            Destroy(inventory.GetComponent<Rigidbody>());
        }*/
    }
}
