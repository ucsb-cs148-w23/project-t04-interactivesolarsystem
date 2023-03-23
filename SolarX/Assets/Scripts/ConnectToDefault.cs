using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConnectToDefault : MonoBehaviour
{
    //private
    private string planetMass; //in kgs
    private string initialMass; //in kgs
    private float planetMassF; //In unity units
    private float initialMassF; //in unity units
    private bool needsUpdate;
    private PlanetaryInfo pinfo;
    private GameObject test;

    //public
    public int planetIndex;
    public TMP_InputField massInput;
    public Toggle AssociatedToggle;

    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.Find("PlanetaryInformation");
        if(test == null){
            Debug.Log("Could not find planet Info");
            planetMass = "1";
            planetMassF = 1f;
        }else{
            pinfo = test.GetComponent<PlanetaryInfo>();
            planetMassF = pinfo.getDefaultPlanetMass(planetIndex);
            Debug.Log("Default Planet Mass: " + pinfo.getDefaultPlanetMass(planetIndex));
            planetMass = unitToKgs(planetMassF).ToString("0.0000");
        }

        initialMassF = planetMassF;
        initialMass = planetMass;
        massInput.text = planetMass;
        AssociatedToggle.isOn = true;
        massInput.interactable = false;
        needsUpdate = false;

        if(test != null){
            if(Mathf.Abs(pinfo.getDefaultPlanetMass(planetIndex) - pinfo.getPlanetMass(planetIndex)) > 0.0001f){
                AssociatedToggle.isOn = false;
                massInput.interactable = true;
                planetMassF = pinfo.getPlanetMass(planetIndex);
                planetMass = unitToKgs(planetMassF).ToString("0.0000");
                massInput.text = planetMass;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Mass at index: "+ planetIndex + " is: " + pinfo.getPlanetMass(planetIndex));
        if(!needsUpdate){
            return;
        }
        
        if( AssociatedToggle.isOn){
            massInput.text = initialMass;
            massInput.interactable = false;
            planetMassF = initialMassF;
            planetMass = initialMass;
            Debug.Log("Toggle is on!");
            needsUpdate = false;
            if(test != null){
                pinfo.setPlanetMass(planetIndex, planetMassF);
            }
            return;
        }else{
            massInput.interactable = true;
        }
        changeMass(massInput.text);
        if(test != null){
            pinfo.setPlanetMass(planetIndex, planetMassF);
        }
        needsUpdate = false;
    }

    //input string is in kg*10^23
    public void changeMass(string str){ //
        float massConv = massStrToFloat(str);
        float a;
        bool isNum = float.TryParse(str, out a);
        if(massConv <= 0.01f || massConv >= 10000000f || !isNum){
            Debug.LogWarning("Value out of Bounds");
            return;
        }

        planetMassF = massConv;
        planetMass = str;
        massInput.text = planetMass;



    }


    //Unit Conversion
    private float kgsToUnit(float kgsVal){
        return kgsVal/59.7219f;
    }

    private float unitToKgs(float unitVal){
        return unitVal * 59.7219f;
    }

    //Convert mass String to mass float w/ unit conversions
    private float massStrToFloat(string massStr){
        float a;
        bool isNum = float.TryParse(massStr, out a);
        if(isNum){
            return kgsToUnit(a);
        }else{
            Debug.LogWarning("Not a Number");
            return planetMassF;
        }
    }

    //Add Update
    public void updated(){
        needsUpdate = true;
    }

    //set mass text equal to stored mass
    public void updateText(){
        massInput.text = planetMass;
    }
   
}
