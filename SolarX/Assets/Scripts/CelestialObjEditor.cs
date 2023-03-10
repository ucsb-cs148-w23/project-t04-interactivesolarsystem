using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObjEditor : MonoBehaviour
{

    //internal GameObject planetEdited;

    // Version that assumes currently stored planet,
    // overloaded version that takes planet to modify?
    public static void SetMass(GameObject planet, float new_mass) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's mass TO modify
        if (planet_rb == null) {

            Debug.LogError("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!");
            return;

        }

        // we're safe, go for it
        planet_rb.mass = new_mass;

    }

    public static void SetMass(string planet_name, float new_mass) {

        GameObject planet = GameObject.Find(planet_name);

        // Check that there's a planet TO modify
        if (planet == null) {

            Debug.LogError("ERROR: The planet " + planet_name + " could not be found!");
            return;

        }

        // Call the other variant
        SetMass(planet, new_mass);

    }

    public static void SetPosition(GameObject planet, Vector3 new_pos) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's a rigidbody TO modify
        if (planet_rb == null) {

            Debug.LogError("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!");
            return;

        }

        // we're safe, go for it
        planet.transform.position = new_pos;
        planet_rb.position = new_pos;

    }

    public static void SetPosition(string planet_name, Vector3 new_pos) {

        GameObject planet = GameObject.Find(planet_name);

        // check that there's a planet TO modify
        if (planet == null) {

            Debug.LogError("ERROR: The planet " + planet_name + " could not be found!");
            return;

        }

        // Call the other variant
        SetPosition(planet, new_pos);

    }

    private Vector3 polarHelper(Vector3 polar_coords) {
        // All the elements in the vector are expected to be floats
        // Polar-coords in 3D are: (radius, theta, phi)

        return Vector3.zero; // STUB

    }

    public static void SetPositionPolar(GameObject planet, Vector3 new_pos) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's a rigidbody TO modify
        if (planet_rb == null) {

            Debug.LogError("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!");
            return;

        }

        // we're safe, go for it
        planet.transform.position = new_pos;
        planet_rb.position = new_pos;

    }

    public static void SetPositionPolar(string planet_name, Vector3 new_pos) {

        // STUB

    }

    public static void SetRadius(GameObject planet, float new_radius) {

        // STUB

    }

    public static void SetRadius(string planet_name, float new_radius) {

        // STUB

    }

    public static void DeletePlanet(GameObject planet) {
        // Maybe add ability to notify the solar system it's planet is gone? Might need to do extra cleanup work too.
        // STUB

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
