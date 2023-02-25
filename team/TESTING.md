# Team04 - Interactive Solar System Test Documentation

## Unit Test Implementation
We created some stub tests, located inside the Unity Project under Assets/Tests/EditMode and Assets/Tests/PlayMode.
The tests were created using Unity's own built-in testing framework, which itself makes use of the NUnit test framework. 

We tried to implement unit tests for SolarSystem.cs, but we were unable to get them working; unit testing for MonoBehaviors was unexpectedly challenging. Unfortunately, almost all of the scripts in our project were MonoBehaviors; thus, we made stub tests as a proof of concept. 

Later, we implemented Unit Tests by taking pieces of code within our MonoBehaviors and converting them into public static member functions. This circumvented the issues we had with accessing the functions and mocking inputs. The Unit Tests replaced the stub unit tests under Assets/Tests/EditMode.

## Future Plans Regarding Unit Tests
We plan to do Unit Testing on other small code snippets, when it makes sense to. We will accomplish this by converting them into public static helper functions, like we did before. Testing will be done feed inputs to the helper function we want to test and check that the results are what we expected. 

It may not make sense to 'Unit Test' much of the project because our code is highly interconnected and much of it is locked behind Unity Monobehaviors. This means that a large portion of the code is dependant on other code, meaning Integration Testing would be more appropriate.

## How Was The Component/Integration/End-to-End Testing Done?
Component Testing was done using Unity's own built-in testing framework, the same one used for our Unit Tests. They are located under Assets/Tests/PlayMode. These tests were done by creating a dummy GameObject, attaching the systems we wanted to test together to it. Due to the nature of the Unity Test Framework, at least two of the component tests we currently have are arguably  integration tests, because they involve multiple object instances interacting with each other.  

Right now, the Component / Integration Testing focuses only on SolarSystem.cs and the Planets it governs. Three tests were made; for each test, one or two dummy planets were made with specific parameters that we expected to cause a certain behavior. Once everything is initialized, the Unity Test Framework runs the test as if it was an active Unity game for a specific period of time. Afterwards, we check if the planets in the solar system behaved as expected (did they move? Are they closer together?). If they did, the component test passes. Otherwise, the component test fails.


## Future Plans Regarding Higher-Level Tests
We plan to write some component / integration tests for some of the other scripts / behaviors, like the recently added pause functionality. We are uncertain if we want to add End-to-End testing for our project; if we chose to do so, more research and experimentation would be needed to see how this could be accomplished in Unity.
