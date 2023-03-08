using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("PlayModeTests")]

public class SolarSystem : MonoBehaviour
{
    // On default settings it seems to take 57.5778 to 57.61898 seconds for Earth to do one full rotation
    // Minimum I was able to capture during a short testing section was distance 1.701292 units from 
    // initial position at 57.59858 seconds. We decide to represent the 'full orbital period' (i.e. one Earth year)
    // as 57.6 seconds of real life time. 

    // NASA Fact Sheet says there's 365.2 Earth Days in a full rotation
    // 8766.144 hours in the Earth year (full rotation using sidereal measurement)

    // Approximate Real-life time it takes for Earth to make a full orbit in the simulation using
    // default settings
    //readonly static float default_earth_year = 57.6f;

    readonly static float G = 100f;
    internal GameObject[] celestials;
    public static float total_time = 0f;
    public static Vector3 init_earth_pos;
    GameObject Earth;


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

    // Maybe the mutator should be internal...
    public void setCelestials(GameObject[] celestials)
    {
        this.celestials = celestials;
    }

    public GameObject[] getCelestials(){
        return this.celestials;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SolarSystem starting", this);

        // for debug / frame-of-reference purposes:
        // Earth = GameObject.Find("Earth");
        // init_earth_pos = Earth.transform.position;
        // Debug.Log("Earth's initial position recorded to be at: " + init_earth_pos.ToString());
        // Debug.Log("Earth's current position on start is: " + Earth.transform.position.ToString());

        celestials = GameObject.FindGameObjectsWithTag("Celestials");
        // Output to Log what SolarSystem is seeing, so we can figure out
        // if there's something wrong with it
        if (celestials == null || celestials.Length == 0) {

            Debug.LogWarning("This SolarSystem found no celestial objects!", this);

        }
        else {

            Debug.Log("Found " + this.celestials.Length.ToString() + " celestial objects at SolarSystem start.", this);

        }
        InitialVelocity(celestials);
    }

    // Update is called once per frame
    void Update()
    {
        total_time += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        Gravity();
        //float relative_dist = Vector3.Distance(Earth.transform.position, init_earth_pos);
        //Debug.Log("Total Time: " + total_time.ToString());
        //Debug.Log("==============================================");
        //Debug.Log("Earth's Current Position: " + Earth.transform.position.ToString());
        //Debug.Log("Earth's Initial Position: " + init_earth_pos.ToString());
        //Debug.Log("Releative Distance: " + relative_dist.ToString());
        // if (total_time > 1f && relative_dist < 5f) {

        //     Debug.LogWarning("Earth returned to original position at approximately" + total_time.ToString() + " seconds.", this);
        //     Debug.Log("The distance was" + relative_dist.ToString(), this);

        // }
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

    public static void InitialVelocity(GameObject[] celestials)
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
