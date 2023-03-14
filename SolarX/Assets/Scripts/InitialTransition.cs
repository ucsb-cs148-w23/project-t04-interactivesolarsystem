using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTransition : MonoBehaviour
{
    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<mainc>().rebackmain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
