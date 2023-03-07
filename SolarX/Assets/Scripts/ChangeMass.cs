//#include <stdio.h>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Change the mass of a planet with the planet and mass you want to change it to as input
    //Mass is in the UnityUnits we are unsing
    void changeMassUnityUnits(Rigidbody rb, float mass){
        //Mass can't be zero or lower and is capped at 1,000,000 just to keep program normal
        /*
        if(mass <= 0 || mass > 1000000){
            Debug.Log("Mass input: " + mass + " is out of bounds");
            return;
        }
        rb.mass = mass;
        */
    }

    //Change the mass of a planet using regular units
    // Units of mass: 10^23 kgs
    void changeMassKgs(Rigidbody rb, float mass){
        //Divide value by mass of the earth because that is what 1 unit is in our unity unit scaling.
        //changeMassUnityUnits(rb, mass/((float)59.7219));
    }
}
