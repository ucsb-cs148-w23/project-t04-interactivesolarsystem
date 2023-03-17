using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIcONTRROL : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject UI;
    private bool isOpen = false;
    private bool isa;
    public GameObject cam; 

    

   public void BackGame()
   {
        
        UI.SetActive(false);
        a.GetComponent<mouselook>().enabled = true;
        b.GetComponent<MoveInSpace>().enabled = true;
        cam.GetComponent<DisconnectCam>().setDisconnected(false);
    }

   public void BackMen()
   {
        SceneManager.LoadScene("main");
   }



   private void Update() {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (isOpen==false)
            {   
                cam.GetComponent<DisconnectCam>().setDisconnected(true); 
                a.GetComponent<mouselook>().enabled = false;
                b.GetComponent<MoveInSpace>().enabled = false; 
                UI.SetActive(true);
               
            }
            else
            {
                cam.GetComponent<DisconnectCam>().setDisconnected(false); 
                UI.SetActive(false);
                a.GetComponent<mouselook>().enabled = true;
                b.GetComponent<MoveInSpace>().enabled = true;
            }
            isOpen = !isOpen;
        }
   }
}
