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

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MoveDown()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //var gameObj = new GameObject();
        //var yid = gameObj.AddComponent<YIDONG>();

        yield return null;
    }
}
