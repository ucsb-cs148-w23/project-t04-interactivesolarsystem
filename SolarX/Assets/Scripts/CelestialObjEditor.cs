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

    public static Vector3 polarHelper(Vector2 polar_coords) {
        // All the elements in the vector are expected to be floats
        // Polar-coords in 2D are: (radius, theta (measured in degrees here))

        float radians = polar_coords[1] * UnityEngine.Mathf.Deg2Rad;

        Vector3 result = Vector3.zero;
        // result[0] is x, result[2] is z (on a 2D x-y plane, x is x and z is y).
        result[0] = polar_coords[0] * UnityEngine.Mathf.Cos(radians);
        result[2] = polar_coords[0] * UnityEngine.Mathf.Sin(radians);

        return result;

    }

    public static void SetPositionPolar(GameObject planet, Vector2 new_pos_pol) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's a rigidbody TO modify
        if (planet_rb == null) {

            Debug.LogError("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!");
            return;

        }

        Vector3 new_pos = polarHelper(new_pos_pol);

        // we're safe, go for it
        planet.transform.position = new_pos;
        planet_rb.position = new_pos;

    }

    public static void SetPositionPolar(string planet_name, Vector2 new_pos_pol) {

        GameObject planet = GameObject.Find(planet_name);

        // check that there's a planet TO modify
        if (planet == null) {

            Debug.LogError("ERROR: The planet " + planet_name + " could not be found!");
            return;

        }

        // Call the other variant
        SetPositionPolar(planet, new_pos_pol);

    }

    public static void SetRadius(GameObject planet, float new_radius) {

        // check that there's a planet TO modify
        if (planet == null) {

            Debug.LogError("ERROR: The planet doesn't exist!");
            return;

        }

        Vector3 new_scale = new Vector3(new_radius, new_radius, new_radius);

        // we're safe, go for it
        planet.transform.localScale = new_scale;

    }

    public static void SetRadius(string planet_name, float new_radius) {

        GameObject planet = GameObject.Find(planet_name);

        // check that there's a planet TO modify
        if (planet == null) {

            Debug.LogError("ERROR: The planet " + planet_name + " could not be found!");
            return;

        }

        // Call the other variant
        SetRadius(planet, new_radius);

    }

    public static void DeletePlanet(GameObject planet, SolarSystem sol) {
        // Maybe add ability to notify the solar system it's planet is gone? Might need to do extra cleanup work too.
        // curr_celestials = sol.getCelestials();

        // int count = 0;
        // foreach (GameObject a in curr_celestials) {

            

        // }

        GameObject.Destroy(planet);
        sol.setCelestials(GameObject.FindGameObjectsWithTag("Celestials"));


    }

}
