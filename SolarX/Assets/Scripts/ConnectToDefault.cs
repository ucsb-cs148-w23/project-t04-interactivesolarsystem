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

    //public
    public int planetIndex;
    public TMP_InputField massInput;
    public Toggle AssociatedToggle;

    // Start is called before the first frame update
    void Start()
    {
        planetMass = "1";
        initialMass = "1";
        planetMassF = 1f;
        initialMassF = planetMassF;
        //initialMassF = planetMassF;
        massInput.text = planetMass;
        AssociatedToggle.isOn = true;
        massInput.interactable = false;
        needsUpdate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!needsUpdate){
            return;
        }
        
        if( AssociatedToggle.isOn){
            massInput.text = initialMass;
            massInput.interactable = false;
            planetMassF = initialMassF;
            planetMass = initialMass;
            Debug.Log("Toggle is on!");
        }else{
            massInput.interactable = true;
        }
        changeMass(massInput.text);
        needsUpdate = false;
    }

    //input string is in kg*10^23
    public void changeMass(string str){ //
        float massConv = massStrToFloat(str);
        float a;
        bool isNum = float.TryParse(str, out a);
        if(massConv <= 0.01f || massConv >= 10000000f || !isNum){
            Debug.LogWarning("Value out of Bounds");
            //smassInput.text = planetMass;
            return;
        }

        planetMassF = massConv;
        planetMass = str;
        massInput.text = planetMass;

        Debug.Log("planet mass in kgs: " + planetMass + ", planet mass in unity: " + planetMassF);

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
    /*
    public float strToFloat(string input){
        float num = 20f;
        return num;
    }

    */
}
