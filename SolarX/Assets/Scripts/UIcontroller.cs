using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private GameObject sawTheObject;
    [SerializeField] private TextMeshProUGUI talkAbout;
    void Start()
    {
        Off();
    }
    public void Off()
    {
        sawTheObject.SetActive(false);
    }
    public void Open(string _text)
    {
        sawTheObject.SetActive(true);
        talkAbout.text = _text;

        //freeze camera
        DisconnectCam.instance.setDisconnected(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
