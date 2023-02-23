using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StubTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestRotationSpeedZeroResultsInZeroRotation()
    {
        Vector3 actual = zizhuan.rotateHelper(Vector3.down, 0);
        Vector3 expected = Vector3.zero;

        Assert.AreEqual(actual, expected);
    }

}
