using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlanetMain : MonoBehaviour
{
    


    private int planetCount = 0;
    bool planetsDisabled = false;
    GameObject[] newPlanetPanels;
    
    GameObject test;
    PlanetaryInfo plan;


    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.Find("PlanetaryInformation");
        if(test != null){
            plan = test.GetComponent<PlanetaryInfo>();
        }

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
            if(test != null){
                int planIndex = newPlanetPanels[i].GetComponent<ConnectToDefault>().planetIndex;
                if(plan.getPlanetsActive(planIndex)){
                    newPlanetPanels[i].SetActive(true);
                    addPlanetCount();
                }
            }
            }
            planetsDisabled = true;
            if(planetCount == newPlanetPanels.Length){
                gameObject.SetActive(false);
            }
        }
        
    }

    public void addPlanetPanel(){
        if(planetCount < newPlanetPanels.Length){
            //newPlanetPanels[planetCount].SetActive(true);
            addNewPlanetToPlanetaryInfo(newPlanetIndex());
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
                if(test != null){
                    plan.setPlanetsActive(adjIndex, true);
                    Debug.Log("Rand planet at index: " + adjIndex + " is set to " + plan.getPlanetsActive(adjIndex));
                }
                newPlanetPanels[i].SetActive(true);
            }
        }
    }

    int newPlanetIndex(){
        int index = 0;
        for(int i = 0; i < newPlanetPanels.Length; i ++){
            if(test != null){
                if(!plan.getPlanetsActive(i + 9)){
                    return i;
                }
            }
        }
        gameObject.SetActive(false);
        return index;
    }

    public void removePlanet(int index){
        int adjIndex = index + 9;
        for(int i = 0; i < newPlanetPanels.Length; i++){
            if(newPlanetPanels[i].GetComponent<ConnectToDefault>().planetIndex == adjIndex){
                if(test != null){
                    plan.setPlanetsActive(adjIndex, false);
                    //Debug.Log("Rand planet at index: " + adjIndex + " is set to " + plan.getPlanetsActive(adjIndex));
                }
                newPlanetPanels[i].SetActive(false);
                planetCount --;
            }
        }

        gameObject.SetActive(true);

    }

}
