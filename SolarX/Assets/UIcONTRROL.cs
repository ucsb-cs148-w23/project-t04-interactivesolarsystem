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
   public void BackGame()
   {
        UI.SetActive(false);
        a.GetComponent<mouselook>().enabled = true;
        b.GetComponent<MoveInSpace>().enabled = true;
    }
   public void BackAbt()
   {
    
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
                a.GetComponent<mouselook>().enabled = false;
                b.GetComponent<MoveInSpace>().enabled = false;
                UI.SetActive(true);
               
            }
            else
            {
                UI.SetActive(false);

                a.GetComponent<mouselook>().enabled = true;
                b.GetComponent<MoveInSpace>().enabled = true;
            }
            isOpen = !isOpen;
        }
   }
}
