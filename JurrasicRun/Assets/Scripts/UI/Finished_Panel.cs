using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished_Panel : MonoBehaviour
{
    [SerializeField] private Eggs eggs;
    [SerializeField] private GameObject UI;
    [SerializeField] private Bird_In_Cage cage;
    public TMPro.TMP_Text score;
    public TMPro.TMP_Text dodo;


    public void Display()
    {
        UI.SetActive(true);
        score.text = (eggs.collectedEggs.ToString() + " / " + eggs.AmountOfAllExisting.ToString());
        if (cage.birdSaved)
            dodo.text = "Found";
        else
            dodo.text = "Not Found";
        
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
