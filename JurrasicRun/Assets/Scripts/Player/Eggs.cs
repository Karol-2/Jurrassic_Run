using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    public int collectedEggs ;
    public int AmountOfAllExisting;
    private void Start()
    {
        collectedEggs = 0;
        AmountOfAllExisting = GameObject.FindGameObjectsWithTag("Egg").Length;
    }


    public void Collected()
    {
        collectedEggs += 1;
        Debug.Log(collectedEggs + " / " + AmountOfAllExisting);
    }


}
