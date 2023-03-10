using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] celestials;
    readonly static float G = 100f;
    ArrayList randomPlanets = new ArrayList();
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestials");
        if (celestials == null || celestials.Length == 0)
        {

            Debug.LogWarning("This SolarSystem found no celestial objects!", this);

        }
        else
        {

            Debug.Log("Found " + this.celestials.Length.ToString() + " celestial objects at AddRandomPlanet start.", this);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Add gravity
        foreach (GameObject randomPlanet in randomPlanets)
        {
            foreach (GameObject b in celestials)
            {
                float m1 = randomPlanet.GetComponent<Rigidbody>().mass;
                float m2 = b.GetComponent<Rigidbody>().mass;
                float r = Vector3.Distance(randomPlanet.transform.position, b.transform.position);

                randomPlanet.GetComponent<Rigidbody>().AddForce(SolarSystem.gravForceHelper(randomPlanet.transform.position, b.transform.position, G, m1, m2, r));
            }
        }
    }

    public void addRandomPlanet()
    {
        Vector3 pos = new Vector3(0f, 0f, Random.Range(1600f, 2400f));
        float mass = Random.Range(1, 100);
        float scale = Random.Range(30, 70);
        Vector3 scaleVec = new Vector3(scale, scale, scale);

        GameObject randomPlanet = buildPlanet(pos, mass, scaleVec);
        randomPlanet.SetActive(true);

        randomPlanets.Add(randomPlanet);


        // Add initial velocity
        foreach (GameObject b in celestials)
        {
            float m2 = b.GetComponent<Rigidbody>().mass;
            float r = Vector3.Distance(randomPlanet.transform.position, b.transform.position);
            randomPlanet.transform.LookAt(b.transform);

            randomPlanet.GetComponent<Rigidbody>().velocity += SolarSystem.initialVelocityHelper(randomPlanet.transform.right,
                                                                            G, m2, r);
        }

        

    }

    GameObject buildPlanet(Vector3 in_pos, float in_mass, Vector3 in_scale, string in_name = "Random")
    {
        GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.name = in_name;
        planet.tag = "Celestials";
        planet.transform.position = in_pos;
        planet.transform.localScale = in_scale;

        planet.AddComponent<Rigidbody>();
        planet.AddComponent<SphereCollider>();
        planet.AddComponent<TrailRenderer>();

        planet.GetComponent<Rigidbody>().mass = in_mass;
        planet.GetComponent<Rigidbody>().useGravity = false;


        return planet;
    }

}
