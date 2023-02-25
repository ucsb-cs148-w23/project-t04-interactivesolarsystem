using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SolarSystemPlayTests
{

    private GameObject gameObj;

    [SetUp]
    public void Setup() {

        gameObj = new GameObject();
        gameObj.AddComponent<SolarSystem>();

    }

    [TearDown]
    public void Teardown() {

        UnityEngine.Object.Destroy(gameObj);

    }

    public GameObject buildDummyCelestial(Vector3 in_pos, float in_mass = 1f, string in_name = "Dummy") {

        GameObject dummy_celestial = new GameObject();
        dummy_celestial.name = in_name;
        dummy_celestial.tag = "Celestials";
        dummy_celestial.transform.position = in_pos;
        dummy_celestial.AddComponent<Rigidbody>();
        dummy_celestial.AddComponent<SphereCollider>();
        dummy_celestial.GetComponent<SphereCollider>().radius = 1f;
        dummy_celestial.GetComponent<Rigidbody>().useGravity = false;
        dummy_celestial.GetComponent<Rigidbody>().position = in_pos;
        dummy_celestial.GetComponent<Rigidbody>().mass = in_mass;
        //dummy_celesital.GetComponent<Rigidbody>().AddComponent<SphereCollider>();
        //dummy_celestial.GetComponent<Rigidbody>().GetComponent<SphereCollider>().radius = 1f;
    


        return dummy_celestial;

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SingularPlanetWithDoesNotMove()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        SolarSystem solSys = gameObj.GetComponent<SolarSystem>() as SolarSystem;
        var planet1 = buildDummyCelestial(Vector3.zero, 1f, "Planet1");

        GameObject[] dummy_celestials = {planet1};

        solSys.celestials = dummy_celestials;

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(Vector3.zero, solSys.celestials[0].GetComponent<Rigidbody>().position);

        // Cleanup
        UnityEngine.Object.Destroy(solSys.celestials[0]);

    }

    [UnityTest]
    public IEnumerator TwoPlanetsWithZeroMassDoNotAttract()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        SolarSystem solSys = gameObj.GetComponent<SolarSystem>() as SolarSystem;
        var planet1 = buildDummyCelestial(Vector3.zero, 0f, "Planet1");
        Vector3 planet2_pos = new Vector3(5f, 0f, 0f);
        var planet2 = buildDummyCelestial(planet2_pos, 0f, "Planet2");

        GameObject[] dummy_celestials = {planet1, planet2};

        // We'll test positions are the same AND that the distances before and after running are the same.
        float init_distance = Vector3.Distance(planet1.GetComponent<Rigidbody>().position, planet2_pos);

        solSys.celestials = dummy_celestials;

        // For some reason, AddForce HATES it when two planets of zero mass attract each other for too long.
        yield return new WaitForSeconds(0.5f);

        float final_distance = Vector3.Distance(planet1.GetComponent<Rigidbody>().position, planet2.GetComponent<Rigidbody>().position);

        Assert.IsTrue(Vector3.zero == solSys.celestials[0].transform.position);
        Assert.AreEqual(planet2_pos, solSys.celestials[1].transform.position);
        Assert.AreEqual(init_distance, final_distance);

        // Cleanup
        UnityEngine.Object.Destroy(solSys.celestials[0]);
        UnityEngine.Object.Destroy(solSys.celestials[1]);

    }

    [UnityTest]
    public IEnumerator TwoPlanetsWithNonzeroMassAttract()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        SolarSystem solSys = gameObj.GetComponent<SolarSystem>() as SolarSystem;
        var planet1 = buildDummyCelestial(Vector3.zero, 1f, "Planet1");
        Vector3 planet2_pos = new Vector3(5f, 0f, 0f);
        var planet2 = buildDummyCelestial(planet2_pos, 1f, "Planet2");

        GameObject[] dummy_celestials = {planet1, planet2};

        // We'll test positions are the same AND that the distances before and after running are the same.
        float init_distance = Vector3.Distance(planet1.GetComponent<Rigidbody>().position, planet2_pos);

        solSys.celestials = dummy_celestials;

        // For some reason, AddForce HATES it when two planets of zero mass attract each other for too long.
        yield return new WaitForSeconds(0.5f);

        float final_distance = Vector3.Distance(planet1.GetComponent<Rigidbody>().position, planet2.GetComponent<Rigidbody>().position);

        Assert.AreNotEqual(Vector3.zero, solSys.celestials[0].GetComponent<Rigidbody>().position);
        Assert.AreNotEqual(planet2_pos, solSys.celestials[1].GetComponent<Rigidbody>().position);
        Assert.IsTrue(init_distance > final_distance);

        // Cleanup
        UnityEngine.Object.Destroy(solSys.celestials[0]);
        UnityEngine.Object.Destroy(solSys.celestials[1]);

    }

}
