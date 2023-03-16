using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCustumPlanets : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] celestials;
    ArrayList customPlanets = new ArrayList();
    string[] planetName = { "Sun Sphere", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
    //int[] customPlanetsIndices = new int[5];
    // Start is called before the first frame update

    AddRandomPlanet addRandomPlanet = new AddRandomPlanet();

    private void Awake()
    {
        Debug.Log("SolarSystem Awake");
        GameObject interPage = GameObject.Find("PlanetaryInformation");
        PlanetaryInfo planetaryInfo = interPage.GetComponent<PlanetaryInfo>();

        //celestials = GameObject.FindGameObjectsWithTag("Celestials");
        //Debug.Log(celestials[0].name);
        
        for (int i = 0; i < 9; i++)
        {
            GameObject celestial = GameObject.Find(planetName[i]);
            Debug.Log("Found " + celestial.name + " at " + i.ToString());
            celestial.GetComponent<Rigidbody>().mass = planetaryInfo.getPlanetMass(i);
        }

        for (int i = 9; i < 14; i++)
        {
            Vector3 pos = new Vector3(0f, 0f, Random.Range(1600f, 8500f));
            float scale = Random.Range(30, 70);
            Vector3 scaleVec = new Vector3(scale, scale, scale);
            float mass = planetaryInfo.getPlanetMass(i);

            GameObject planet = addRandomPlanet.buildPlanet(pos, mass, scaleVec);
            planet.AddComponent<SelfRotation>();
            if (!planetaryInfo.getPlanetsActive(i))
            {
                planet.SetActive(false);
            }
            
        }
        Debug.Log("Custom Planets Created.");

    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
