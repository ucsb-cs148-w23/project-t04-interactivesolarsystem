using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class zizhuan : MonoBehaviour
{

    public static Vector3 rotateHelper (Vector3 vector_in, float rotationSpeed) {
        // Pulled this out so it can be unit tested for the sake of the requirements
        return vector_in * rotationSpeed;

    }

    public float _RotationSpeed; //������ת���ٶ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pull Vector3.down * _RotationSpeed into a seperate function and test it
        transform.Rotate(rotateHelper(Vector3.down, _RotationSpeed), Space.World);
    }
}
