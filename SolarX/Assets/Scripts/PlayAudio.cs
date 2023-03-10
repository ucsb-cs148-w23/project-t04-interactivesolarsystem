using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public GameObject xinxi;
    [SerializeField, TextArea] private string theText;
    private void OnMouseDown()
    {
        UIcontroller.instance.Open(theText);
        xinxi.SetActive(false);
    }


}
