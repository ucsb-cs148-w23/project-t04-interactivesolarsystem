using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{

    GameObject makeFakePlanet(Vector3 in_position, Vector3 in_velocity, string name="Default", float in_mass=1) {

        var fake = new GameObject(name);
        fake.tag += "Celestials";
        fake.AddComponent<Rigidbody>();
        fake.GetComponent<Rigidbody>().mass = in_mass;
        fake.GetComponent<Rigidbody>().position = in_position;
        fake.GetComponent<Rigidbody>().velocity = in_velocity;

        return fake;

    }
    
    [UnityTest]
    public IEnumerator InitialVelocityAtZeroMassIsZero()
    {

        var dummyObject = new GameObject();

        GameObject planet1 = makeFakePlanet(Vector3.zero, Vector3.zero, "Planet1", 0);
        GameObject planet2 = makeFakePlanet(new Vector3(1.0f, 0.0f, 0.0f), Vector3.zero, "Planet2", 0);

        var SolarS = dummyObject.AddComponent<SolarSystem>();

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(planet1.GetComponent<Rigidbody>().velocity, Vector3.zero);
        Assert.AreEqual(planet2.GetComponent<Rigidbody>().velocity, Vector3.zero);
    }
}
