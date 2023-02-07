using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mouselook : MonoBehaviour
{
    //sensitivity => ¡È√Ù∂»
    public float MouseSensitivity = 100f;

    public Transform PlayerBody;

    private float XRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * MouseX);

    }
}

