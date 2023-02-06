using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Handler : MonoBehaviour
{

    // We assume that 1 unit of Mass in Unity is equal to
    // 1 * (10^24) Kilograms (standard when describing celestial bodies)

    // Gravitational Constant is 6.67 × 10^-11 (Newtons * m^2)/(kg^2)
    // We can make a new gravitational constant with different units by solving
    // a change of units problem, where we convert m (meters) to AU and kg (kilograms) to
    // Earth masses (or some other large mass)

    // Each Unity distance unit is measured to about 0.2 AU

    //const float G = 0.00000000006674f;
    const float G = 6.674f; // incorrect value, but other value caused things to barely move
    //static readonly float G = 1.063f*Mathf.Pow(10,17); // Assumes distance is AUs and mass is in Earths

    public static List<Gravity_Handler> Gravity_Handlers;

    public Rigidbody rb;

    void FixedUpdate () {

        foreach (Gravity_Handler grav_obj in Gravity_Handlers) {

            if (grav_obj != this) {

                Attract(grav_obj);

            }

        }

    }

    void OnEnable () {

        if (Gravity_Handlers == null) {

            Gravity_Handlers = new List<Gravity_Handler>();

        }

        Gravity_Handlers.Add(this);

    }

    void OnDisable () {

        Gravity_Handlers.Remove(this);

    }
    
    void Attract (Gravity_Handler obj_to_attract) {

        Rigidbody rb_to_attract = obj_to_attract.rb;

        Vector3 direction = rb.position - rb_to_attract.position;
        float distance = direction.magnitude;

        if (distance == 0f) {

            return;
            
        }

        // I've heard that there is a way to optimize this implementation that I haven't applied for now
        // essentially, dividing by Mathf.Pow() is inefficient compared to another datatype
        // that would automatically handle it
        float forceMagnitude = G * (rb.mass * rb_to_attract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb_to_attract.AddForce(force);

    }
    
}
