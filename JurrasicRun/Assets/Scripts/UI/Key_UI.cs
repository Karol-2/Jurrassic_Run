using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_UI : MonoBehaviour
{
    public GameObject player;
    public GameObject keyGUI;
    public GameObject frame;
    private void Start()
    {
        keyGUI.GetComponent<Image>().enabled = false;
        frame.GetComponent<Image>().enabled = false;
    }
    private void Update()
    {
        if(player.GetComponent<GrabController>().hasKey == true)
        {
            keyGUI.GetComponent<Image>().enabled = true;
            frame.GetComponent<Image>().enabled = true;
        }    
        else
        {
            keyGUI.GetComponent<Image>().enabled = false;
            frame.GetComponent<Image>().enabled = false;
        }
    }


}

