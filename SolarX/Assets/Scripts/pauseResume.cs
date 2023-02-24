using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseResume : MonoBehaviour
{
    public bool isPaused = false;
    readonly float G = 100f;

    public Image buttonIcon;
    public Sprite pauseButton;
    public Sprite resumeButton;
    public GameObject Sun;
    GameObject[] celestials;
    //public Vector3 v;
    //public Vector3 av;
    //public Vector3 gravity;

    public void Start()
    {
        Sun = GameObject.Find("Sun Sphere");
        //v = earth.GetComponent<Rigidbody>().velocity;
        //av = earth.GetComponent<Rigidbody>().angularVelocity;
        celestials = GameObject.FindGameObjectsWithTag("Celestials");
        //gravity = earth.GetComponent<Rigidbody>()
    }
    

    public void ButtonClicked()
    {
        isPaused = !isPaused;

        if (isPaused == true)
        {
            foreach (GameObject planet in celestials)
            {
                planet.GetComponent<zizhuan>().enabled = false;
                if (!planet.Equals(Sun))
                {
                    
                    planet.GetComponent<Rigidbody>().isKinematic = true;
                    planet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                
            }
            //earth.GetComponent<zizhuan>().enabled = false;
            //earth.GetComponent<Rigidbody>().isKinematic = true;
            buttonIcon.sprite = resumeButton;
            
        } else
        {
            foreach (GameObject planet in celestials)
            {
                planet.GetComponent<zizhuan>().enabled = true;
                if (!planet.Equals(Sun))
                {
                    planet.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            InitialVelocity();
            buttonIcon.sprite = pauseButton;
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }

}
