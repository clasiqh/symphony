using UnityEngine;
using UnityEditor;
using System.Collections;

public class Camera_LookOnly : MonoBehaviour
{
    //Created by Lex4art at 10 June 2018. This script adds free camera controls via WASD/arrows keys + mouse
    //Hold "Shift" to increase movement speed or hold "Space" to decrease it. Hold "E" or "Q" to up/down movement.

    public int MovementSpeed = 1;        //Basic camera movement spee; default is "50".
    public int MouseSensitivity = 20;    //Than more that value than more sensitive mouse movement; default is "100".


    private float MouseSensitivityNormalized;
    private float MovementSpeedNormalized;
    private float RotationHorizontal = 0.0f;
    private float RotationVertical = 0.0f;


    void Start()
    {
#if (UNITY_EDITOR) //Hide cursor in "Play" mode; only inside Unity editor.
        Cursor.lockState = CursorLockMode.Locked;
#endif
        RotationHorizontal = this.transform.eulerAngles.y;    //Inhernit camera's horizontal orientation from editor.
    }


    void Update()
    {
#if (UNITY_EDITOR) //Hide cursor in "Play" mode after losing viewport focus and bringing back cursor again; only inside Unity editor.
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
#endif

        MouseSensitivityNormalized = ((MouseSensitivity / Time.deltaTime) / 100) * Time.deltaTime;
        RotationHorizontal += Input.GetAxis("Mouse X") * MouseSensitivityNormalized;
        RotationHorizontal = Mathf.Clamp(RotationHorizontal, 166, 194);

        RotationVertical += Input.GetAxis("Mouse Y") * MouseSensitivityNormalized;
        RotationVertical = Mathf.Clamp(RotationVertical,-12,4);

        transform.localRotation = Quaternion.AngleAxis(RotationHorizontal, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(RotationVertical, Vector3.left);



    }
}