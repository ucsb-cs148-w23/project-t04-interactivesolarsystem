using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mouselook : MonoBehaviour
{
    //sensitivity => ������
    public float MouseSensitivity = 100f;

    public Transform PlayerBody;

    private float XRotation = 0f;

    Quaternion localspace;
    float MouseX;
    float MouseY;

    //For checking if the "escape" mode is on
    private bool ePressed;


    // Start is called before the first frame update
    void Awake()
    {
        localspace = gameObject.transform.rotation;
        MouseX = localspace.x;
        MouseY = localspace.y;

        ePressed = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        wasEPressed();
        if(ePressed){
            return;
        }

        MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation =  Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * MouseX);
    }

    private void wasEPressed(){
        if(Input.GetKeyDown(KeyCode.E)){
            ePressed = !ePressed;
            //Debug.Log("E key was pressed, now value is" + ePressed);
        }
    }
}


