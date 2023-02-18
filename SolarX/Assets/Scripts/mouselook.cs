using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mouselook : MonoBehaviour
{
    //sensitivity => ¡È√Ù∂»
    public float MouseSensitivity = 100f;

    public Transform PlayerBody;

    private float XRotation = 0f;

    Quaternion localspace;
    float MouseX;
    float MouseY;


    // Start is called before the first frame update
    void Awake()
    {
        localspace = gameObject.transform.rotation;
        MouseX = localspace.x;
        MouseY = localspace.y;
   
        
    }

    // Update is called once per frame
    void Update()
    {
    
      
        MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
         MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation =  Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * MouseX);

    }
}

