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
    private int planetIndex;

    private float[] planetPositions;
    

    // Start is called before the first frame update
    void Start()
    {
        
        planetPositions = new float[] {Random.Range(1080f, 1610f), Random.Range(1670f, 5000f), Random.Range(5400f, 10100f), Random.Range(10500f, 20000f), Random.Range(21000f, 30000)};
        planetIndex = gameObject.GetComponent<ConnectToDefault>().planetIndex;
        planetInfoObject = GameObject.Find("PlanetaryInformation");
        if(planetInfoObject != null){
            pInfo = planetInfoObject.GetComponent<PlanetaryInfo>();
            menu.value = pInfo.distSetting[planetIndex - 9];
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printOutDropDownVal(){
        Debug.Log(menu.value.ToString());
    }

    public void updatePlanetInfo(){
        float planetPos = planetPositions[menu.value];
        pInfo.setPlanetPosition(planetIndex-9, planetPos);
        pInfo.distSetting[planetIndex - 9] = menu.value;
        Debug.Log(planetPos);
    }

    
}