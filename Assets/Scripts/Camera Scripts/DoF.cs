using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoF : MonoBehaviour
{

    private float depthOfFeild;


    void Start()
    {
 
    }

    void SetFocus()
    {
        
        depthOfFeild = CastRay.hitDistance;
    }


}
