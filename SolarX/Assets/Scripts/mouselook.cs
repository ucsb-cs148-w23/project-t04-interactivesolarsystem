// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;



// public class mouselook : MonoBehaviour
// {
//     //sensitivity => ������
//     public float MouseSensitivity = 100f;

//     public Transform PlayerBody;

//     private float XRotation = 0f;

//     Quaternion localspace;
//     float MouseX;
//     float MouseY;


//     // Start is called before the first frame update
//     void Awake()
//     {
//         localspace = gameObject.transform.rotation;
//         MouseX = localspace.x;
//         MouseY = localspace.y;
   
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(DisconnectCam.instance.getDisconnected()){
//             return;
//         }
        
//         MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
//          MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

//         XRotation -= MouseY;
//         XRotation = Mathf.Clamp(XRotation, -90f, 90f);

//         transform.localRotation =  Quaternion.Euler(XRotation, 0f, 0f);

//         PlayerBody.Rotate(Vector3.up * MouseX);

//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook: MonoBehaviour{
    [Tooltip("A multiplier to the input. Describes the maximum speed in degrees / second. To flip vertical rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity; 

    private Vector2 rotation; 

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"), 
            Input.GetAxis("Mouse Y")
        );
        
        return input; 
    }
}

private void Update()
{
    //The wanted velocity is the current input scaled by the sensitivity 
    //This is also the maximum velocity 

    Vector2 wantedVelocity = GetInput * sensitivity; 
    
    //New rotation 
    rotation += watnedVelocity * Time.deltaTime; 

    //Convert the rotation to euler angles 
    transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0); 
}
