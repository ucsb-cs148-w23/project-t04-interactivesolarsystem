using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InitialVelocityTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DirectionVectorZeroResultsInZeroVelocity()
    {
        // The other values besides 'direction' shouldn't matter if the function
        // works properly.
        Vector3 actual = SolarSystem.initialVelocityHelper(Vector3.zero, 100f, 10f, 10f);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void GravityConstantZeroResultsInZeroVelocity()
    {

        Vector3 actual = SolarSystem.initialVelocityHelper(Vector3.right, 0f, 10f, 10f);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);

    }

    [Test]
    public void OtherMassZeroResultsInZeroVelocity()
    {

        Vector3 actual = SolarSystem.initialVelocityHelper(Vector3.right, 100f, 0f, 10f);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);

    }

    // We should test what happens with distance = 0; would be divide by zero so we need some
    // way to prevent such an eventuality.

}
