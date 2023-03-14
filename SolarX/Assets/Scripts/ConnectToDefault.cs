using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConnectToDefault : MonoBehaviour
{
    private string planetMass;
    private string initialMass;
    public TMP_InputField massInput;
    public Toggle AssociatedToggle;

    // Start is called before the first frame update
    void Start()
    {
        planetMass = "initial value";
        initialMass = "initial mass";
        massInput.text = planetMass;
    }

    // Update is called once per frame
    void Update()
    {
        if( AssociatedToggle.isOn){
            massInput.text = initialMass;
            
        }
        planetMass = massInput.text;
    }
 /*
    public void getInputString(string str){
        planetMass = str;
    }
*/
    public void changeString(string str){
        
        planetMass = str;
        massInput.text = planetMass;

    }
    
    public void addSomethingPlease(){
        return;
    }
}
