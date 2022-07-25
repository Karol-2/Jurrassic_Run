using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_UI : MonoBehaviour
{
    public GameObject player;
    public GameObject klucz;
    private void Start()
    {
        klucz.GetComponent<Image>().enabled = false;
    }
    private void Update()
    {
        if(player.GetComponent<GrabController>().hasKey == true)
            klucz.GetComponent<Image>().enabled = true;
        else
            klucz.GetComponent<Image>().enabled = false;
    }


}

