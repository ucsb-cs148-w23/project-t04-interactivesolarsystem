using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("PlayModeTests")]

public class SolarSystem : MonoBehaviour
{

    readonly float G = 100f;
    internal GameObject[] celestials;

    // Testable helper functions
    public static Vector3 initialVelocityHelper(Vector3 direction, float grav_const, 
        float other_mass, float distance) {
        // Used in initialVelocity
        return direction * Mathf.Sqrt((grav_const * other_mass) / distance);

    }

    public static Vector3 gravForceHelper(Vector3 pos1, Vector3 pos2, float grav_const, float mass1, float mass2, float distance) {
        // Provides a testable helper function for the gravity calculation
        // Inputs: 
        //  Vector3 pos1: position of planet that gravitational force is being applied to
        //  Vector3 pos2: position of planet applying gravitational force
        //  float grav_const: The gravity constant to be used
        //  float mass1: mass of planet that gravitational force is being applied to
        //  float mass2: mass of planet applying gravitational force
        //  float distance: distance between planet1 and planet2
        // Returns a Vector3 representing the gravitational force applied to planet1 by planet2.

        //Debug logs for testing, but we don't want them active all the time... figure out a way to toggle them.
        //Debug.Log(((pos2 - pos1).normalized * (grav_const * (mass1 * mass2) / (distance * distance))).ToString());
        //Debug.Log("Position1: " + pos1.ToString() + ", Position2: " + pos2.ToString());
        //Debug.Log("Normalized distance:" + ((pos2 - pos1).normalized).ToString());
        return (pos2 - pos1).normalized * (grav_const * (mass1 * mass2) / (distance * distance));

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SolarSystem starting", this);

        celestials = GameObject.FindGameObjectsWithTag("Celestials");
        // Output to Log what SolarSystem is seeing, so we can figure out
        // if there's something wrong with it
        if (celestials == null || celestials.Length == 0) {

            Debug.LogWarning("This SolarSystem found no celestial objects!", this);

        }
        else {

            Debug.Log("Found " + this.celestials.Length.ToString() + " celestial objects at SolarSystem start.", this);

        }
        InitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
        
    }

    void Gravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    // I don't think we guard against distance being 0. We should probably fix that.
                    //(b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r))
                    a.GetComponent<Rigidbody>().AddForce(gravForceHelper(a.transform.position, b.transform.position, G, m1, m2, r));
                }
                
            }
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += initialVelocityHelper(a.transform.right, 
                                                                                    G, m2, r);
                }
            }
        }
    }
}
