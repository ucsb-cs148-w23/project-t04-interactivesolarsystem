using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIcONTRROL : MonoBehaviour
{
   public GameObject UI;

    private bool isa;
   public void BackGame()
   {
        UI.SetActive(false);
   }

   public void BackMen()
   {
        SceneManager.LoadScene("main");
   }

   private void Update() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
             
            UI.SetActive(true);
        }
   }
}
