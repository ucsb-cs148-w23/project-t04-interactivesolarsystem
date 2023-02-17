using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SolarSystem;

public class Solar_System_Gravity_EditMode
{

    GameObject makeFakePlanet(Vector3 position, string name="Default", float mass=1, float size=1) {

        fake = new GameObject(name, typeof(Sphere));
        fake.tag += "Celestials";
        fake.AddComponent<RigidBody>();

    }
    
    // A Test behaves as an ordinary method
    [Test]
    public void Solar_System_Gravity_EditModeSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    // Test below is disabled, for now.

    //[UnityTest]
    //public IEnumerator Solar_System_Gravity_EditModeWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
