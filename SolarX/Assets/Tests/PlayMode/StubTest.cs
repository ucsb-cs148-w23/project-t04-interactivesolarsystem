using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StubTest
{

    private GameObject gameObj = new GameObject();

    [SetUp]
    public void Setup() {

        gameObj.AddComponent<SolarSystem>();

    }

    [TearDown]
    public void Teardown() {

        UnityEngine.Object.Destroy(gameObj.GetComponent<SolarSystem>());

    }

    public GameObject buildDummyCelestial(Vector3 in_pos, float in_mass = 1f, string in_name = "Dummy") {

        GameObject dummy_celestial = new GameObject();
        dummy_celestial.name = in_name;
        dummy_celestial.tag = "Celestials";
        dummy_celestial.AddComponent<Rigidbody>();
        dummy_celestial.GetComponent<Rigidbody>().position = in_pos;
        dummy_celestial.GetComponent<Rigidbody>().mass = in_mass;

        return dummy_celestial;

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SingularPlanetDoesNotMove()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //SolarSystem solSys = gameObj.GetComponent<SolarSystem>();
        

        yield return null;
    }
}
