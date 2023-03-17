using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewPlanetDistance : MonoBehaviour
{
    public TMP_Dropdown menu;

    private GameObject planetInfoObject;
    private PlanetaryInfo pInfo;

    private float[] planetPositions;

    // Start is called before the first frame update
    void Start()
    {
        
        planetPositions = new float[] {Random.Range(0.3f, 20.0f), Random.Range(0.3f, 20.0f), Random.Range(0.3f, 20.0f), Random.Range(0.3f, 20.0f)};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printOutDropDownVal(){
        Debug.Log(menu.value.ToString());
    }

    
}
