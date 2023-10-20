using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookcam : MonoBehaviour
{


    public Transform cam;

    void Start()
    {
        cam=Camera.main.transform;    
    }

    
    void LateUpdate()
    {
        transform.LookAt(transform.position+cam.rotation*-Vector3.forward,cam.rotation*Vector3.up);
    }
}
