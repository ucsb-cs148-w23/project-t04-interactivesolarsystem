using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObjEditor : MonoBehaviour
{

    //internal GameObject planetEdited;

    // Version that assumes currently stored planet,
    // overloaded version that takes planet to modify?
    void SetMass(GameObject planet, float new_mass) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's mass TO modify
        if (planet_rb == null) {

            Debug.Error("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!", this);
            return;

        }

        // we're safe, go for it
        planet_rb.mass = new_mass;

    }

    void SetMass(string planet_name, float new_mass) {

        GameObject planet = GameObject.Find(planet_name);

        // Check that there's a planet TO modify
        if (planet == null) {

            Debug.Error("ERROR: The planet " + planet_name + " could not be found!", this);
            return;

        }

        // Call the other variant
        this.SetMass(planet, new_mass);

    }

    void SetPosition(GameObject planet, Vector3 new_pos) {

        var planet_rb = planet.GetComponent<Rigidbody>();

        // check that there's a rigidbody TO modify
        if (planet_rb == null) {

            Debug.Error("ERROR: The planet " + planet.ToString() + " doesn't have a rigidbody component!", this);
            return;

        }

        // we're safe, go for it
        planet.transform.position = new_pos;
        planet_rb.position = new_pos;

    }

    void SetPosition(string planet_name, Vector3 new_pos) {

        GameObject planet = GameObject.Find(planet_name);

        // check that there's a planet TO modify
        if (planet == null) {

            Debug.Error("ERROR: The planet " + planet_name + " could not be found!", this);
            return;

        }

        // Call the other variant
        this.SetPosition(planet, new_mass);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
