//Credits to 2020 NedMakesGames (Youtube)

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour{
    [Flags] public enum RotationDirection
    {
        None, 
        Horizontal = (1 << 0), 
        Vertical = (1 << 1)
    }

    [Tooltip("Which directions the camera can rotate")]
    [SerializeField] private RotationDirection rotationDir; 
    [Tooltip("The rotation acceleration, in degrees/second")]
    [SerializeField] private Vector2 acceleration;
    [Tooltip("A multiplier to the input. Describes the maximum speed in degrees / second. To flip vertical rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity; 
    [Tooltip("The maximum angle from the horizon that the player can rotate, in degrees")]
    [SerializeField] private float maxVerticalAngleFromHorizon;
    [Tooltip("The period to wait until resetting the input value. Set this as low as possiible, without encountering stuttering")]
    [SerializeField] private float inputLagPeriod;



    private Vector2 velocity; 
    private Vector2 rotation; 
    private Vector2 lastInputEvent;
    private float inputLagTimer; 

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime; 

        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"), 
            Input.GetAxis("Mouse Y")
        );

        if((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod){
            lastInputEvent = input;
            inputLagTimer = 0; 
        }
        
        return lastInputEvent; 
    }

    private void Update()
    {
        //Disconnects when e key is pressed 
        if(DisconnectCam.instance.getDisconnected()){
            return;
        }
        //The wanted velocity is the current input scaled by the sensitivity 
        //This is also the maximum velocity 

        Vector2 wantedVelocity = GetInput() * sensitivity; 

        if((rotationDir & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0; 
        }

        if((rotationDir & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0; 
        }

        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime), 
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)); 
        
        //New rotation 
        rotation += velocity  * Time.deltaTime; 
        rotation.y = ClampVerticalAngle(rotation.y);

        //Convert the rotation to euler angles 
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0); 
    }
}
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
//         MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

//         XRotation -= MouseY;
//         XRotation = Mathf.Clamp(XRotation, -90f, 90f);

//         transform.localRotation =  Quaternion.Euler(XRotation, 0f, 0f);

//         PlayerBody.Rotate(Vector3.up * MouseX);

//     }
// }

