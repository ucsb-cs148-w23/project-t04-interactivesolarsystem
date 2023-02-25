using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StubTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void RotationSpeedZeroResultsInZeroRotation()
    {
        Vector3 actual = SelfRotation.rotateHelper(Vector3.down, 0);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void HighRotationSpeedResultsInLargeRotationVector()
    {

        Vector3 actual = SelfRotation.rotateHelper(Vector3.down, 1000);
        Vector3 expected = new Vector3(0f, -1000f, 0f);

        Assert.AreEqual(actual, expected);

    }

}
