using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSpace : MonoBehaviour
{
    public CharacterController CharacterController;

    public float Speed = 750;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; 
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;

        if(DisconnectCam.instance.getDisconnected()){
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //if shift is pressed, double the movement speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 1500;
        }
        else
        {
            Speed = 750;
        }
        Vector3 MoveDir = transform.right * x + transform.forward * y;
        
        CharacterController.Move(MoveDir * Speed * Time.deltaTime);
        if (Input .GetKey (KeyCode.Space))
        {
            gameObject.transform.position= new Vector3(gameObject .transform .position .x ,gameObject .transform .position .y + Speed * Time.deltaTime, gameObject .transform .position .z );
        }
        if (Input .GetKey(KeyCode.Z))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Speed * Time.deltaTime, gameObject.transform.position.z);
        }
    }
}
