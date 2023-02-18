using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SolarSystemHandler;

public class SolarSystemTests
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

    // Just put everything on ice for now.
    
    // A Test behaves as an ordinary method
    //[Test]
    //public void Solar_System_TestsSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //    GameObject planet1 = makeFakePlanet(Vector3.zero, Vector3.zero, "Planet1", 0);
    //    GameObject planet2 = makeFakePlanet(Vector3(1.0f, 0.0f, 0.0f), Vector3.zero, "Planet2", 0);

    //    GameObject dummy_solar_sys = new GameObject("Dummy");
    //    dummy_solar_sys.AddComponent<SolarSystem>();
    //    dummy_solar_sys.GetComponent<SolarSystem>().Start();

    //    Assert.AreEqual(planet1.GetComponent<Rigidbody>().velocity, Vector3.zero);
    //    Assert.AreEqual(planet2.GetComponent<Rigidbody>().velocity, Vector3.zero);

    //}

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    // Test below is disabled, for now.

    //[UnityTest]
    //public IEnumerator Solar_System_TestsWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
