using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YIDONG : MonoBehaviour
{
    public CharacterController CharacterController;

    public float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if camera is locked!
        if(mouselook.instance.getDisconnectCam()){
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

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
