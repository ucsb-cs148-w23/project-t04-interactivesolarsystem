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
    private bool disconnectCam;
    private bool canReconnect;

    //For allowing functions in this class to be used in other programs
    public static mouselook instance;


    // Start is called before the first frame update
    void Awake()
    {
        localspace = gameObject.transform.rotation;
        MouseX = localspace.x;
        MouseY = localspace.y;

        disconnectCam = false;
        canReconnect = true;

        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
        wasEPressed();
        if(disconnectCam){
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
        if(Input.GetKeyDown(KeyCode.E) && canReconnect){
            disconnectCam = !disconnectCam;
            //Debug.Log("E key was pressed, now value is" + ePressed);
        }
    }

    //To change the disconnectCam state to given state
    public void setEPressed(bool eVal){
        disconnectCam = eVal;
        canReconnect = !eVal;
    }

    public bool getDisconnectCam(){
        return disconnectCam;
    }
}


