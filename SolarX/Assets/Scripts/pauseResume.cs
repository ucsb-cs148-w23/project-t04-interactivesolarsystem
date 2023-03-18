using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseResume : MonoBehaviour
{
    public bool isPaused = false;

    public Image buttonIcon;
    public Sprite pauseButton;
    public Sprite resumeButton;
    public GameObject Sun;
    GameObject solarSystem;
    SolarSystem solar;
    GameObject[] celestials;

    public void Start()
    {
        Sun = GameObject.Find("Sun Sphere");
        solarSystem = GameObject.Find("SolarSystem");
        solar = solarSystem.GetComponent<SolarSystem>();
        //celestials = GameObject.FindGameObjectsWithTag("Celestials");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonClicked();
        }
    }


    public void ButtonClicked()
    {
        isPaused = !isPaused;
        celestials = solar.getCelestials();
        if (isPaused == true)
        {
            foreach (GameObject planet in celestials)
            {
                planet.GetComponent<SelfRotation>().enabled = false;
                if (!planet.Equals(Sun))
                {
                    planet.GetComponent<Rigidbody>().isKinematic = true;
                    planet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                
                
            }
            buttonIcon.sprite = resumeButton;
            
        } else
        {
            foreach (GameObject planet in celestials)
            {
                planet.GetComponent<SelfRotation>().enabled = true;
                if (!planet.Equals(Sun))
                {
                    planet.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            SolarSystem.InitialVelocity(celestials);
            buttonIcon.sprite = pauseButton;
        }
    }

    //void InitialVelocity()
    //{
    //    foreach (GameObject a in celestials)
    //    {
    //        foreach (GameObject b in celestials)
    //        {
    //            if (!a.Equals(b))
    //            {
    //                float m2 = b.GetComponent<Rigidbody>().mass;
    //                float r = Vector3.Distance(a.transform.position, b.transform.position);
    //                a.transform.LookAt(b.transform);

    //                a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
    //            }
    //        }
    //    }
    //}

}
