using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{

    // When this is 7.2f, a rotation speed of 1 should result in one rotation per second.
    // So Earth's rotation period of 23.9345 hours (because we're using sidereal rotation period)
    internal static float time_factor = 7.2f;

    public static Vector3 rotateHelper(Vector3 vector_in, float rotationSpeed)
    {
        // Pulled this out so it can be unit tested for the sake of the requirements
        return vector_in * rotationSpeed;

    }

    // The default for a long time was _RotationSpeed = 0.2f;
    public float _RotationSpeed; //������ת���ٶ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Each rotation is by rotateHelper degrees; so if rotate helper is (1, 0, 0)
        // then each update the planet will rotate 1 degree along x-axis (or something like that).
        // By default, fixedupdate calls 50 times per second; this stability is why I switched to it
        // over regular Update().
        transform.Rotate(rotateHelper(Vector3.down, _RotationSpeed*time_factor), Space.World);
    }
}
