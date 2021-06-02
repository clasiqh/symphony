using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private static GameObject detected;
    private GameObject planeTop;
    public Color topColor;
    private UnityEngine.Video.VideoPlayer videoPlayer;
    // Update is called once per frame

    void Awake()
    {
        planeTop = GameObject.Find("PlaneTop");
        planeTop.SetActive(true);
        videoPlayer = planeTop.GetComponent<UnityEngine.Video.VideoPlayer>();

    }


    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            detected = hit.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                switch (detected.name)
                {
                    case "play":
                        Debug.Log(detected.name);
                        break;

                    case "options":
                        Debug.Log(videoPlayer.url);
                        break;

                    default:
                        Debug.Log(detected.name);
                        break;
                }

            }
                
        }

    }


}
