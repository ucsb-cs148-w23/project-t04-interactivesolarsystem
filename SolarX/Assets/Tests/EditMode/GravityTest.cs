using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GravityTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TwoPlanetsOfMassZeroProduceNoForce()
    {
        // The other values besides 'direction' shouldn't matter if the function
        // works properly.
        Vector3 position2 = new Vector3(0f,5f,0f);
        Vector3 actual = SolarSystem.gravForceHelper(Vector3.zero, position2, 100f, 0f, 0f, 5f);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);
    }


    // We should test other types of interactions

}
