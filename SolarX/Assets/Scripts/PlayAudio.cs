using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField, TextArea] private string theText;
    private void OnMouseDown()
    {
        UIcontroller.instance.Open(theText);
    }
}