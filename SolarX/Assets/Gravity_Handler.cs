using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Handler : MonoBehaviour
{

    // We assume that 1 unit of Mass in Unity is equal to
    // 1 * (10^24) Kilograms (standard when describing celestial bodies)

    // Gravitational Constant is

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

        float forceMagnitude = (rb.mass * rb_to_attract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb_to_attract.AddForce(force);

    }
    
}
