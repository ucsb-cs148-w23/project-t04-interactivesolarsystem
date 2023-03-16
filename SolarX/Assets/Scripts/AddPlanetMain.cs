using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlanetMain : MonoBehaviour
{

    private int planetCount = 0;
    bool planetsDisabled = false;
    GameObject[] newPlanetPanels;

    // Start is called before the first frame update
    void Start()
    {
        
        newPlanetPanels = GameObject.FindGameObjectsWithTag("NewPlanetPanel");
        if(newPlanetPanels == null || newPlanetPanels.Length == 0){
            Debug.LogWarning("No Panels found!");
        }
        else{
            Debug.Log("Found: "+ this.newPlanetPanels.Length.ToString() + "at start");
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(!planetsDisabled){
            for(int i = 0; i < newPlanetPanels.Length; i ++){
            newPlanetPanels[i].SetActive(false);
            }
            planetsDisabled = true;
        }
        
    }

    public void addPlanetPanel(){
        if(planetCount < newPlanetPanels.Length){
            //newPlanetPanels[planetCount].SetActive(true);
            addNewPlanetToPlanetaryInfo(planetCount);
            addPlanetCount();
        }else{
            Debug.Log("Already Added enough planets");
        }
        if(planetCount == newPlanetPanels.Length){
            gameObject.SetActive(false);
        }
    }

    public void addPlanetCount(){
        planetCount ++;
    }

    public void addNewPlanetToPlanetaryInfo(int index){
        int adjIndex = index + 9;
        for(int i = 0; i < newPlanetPanels.Length; i++){
            if(newPlanetPanels[i].GetComponent<ConnectToDefault>().planetIndex == adjIndex){
                GameObject test = GameObject.Find("PlanetaryInformation");
                if(test != null){
                    PlanetaryInfo plan = test.GetComponent<PlanetaryInfo>();
                    plan.setPlanetsActive(adjIndex, true);
                    Debug.Log("Rand planet at index: " + adjIndex + " is set to " + plan.getPlanetsActive(adjIndex));
                }
                newPlanetPanels[index].SetActive(true);
            }
        }
    }

    GameObject buildPanel(){
        GameObject panel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        return panel;
    }
}
