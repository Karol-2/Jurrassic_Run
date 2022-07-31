using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished_Panel : MonoBehaviour
{
    [SerializeField] private Eggs eggs;
    [SerializeField] private GameObject UI;
    [SerializeField] private Bird_In_Cage cage;
    [SerializeField] private GameObject crossfade;

    private float transitionTime = 1f;
    public TMPro.TMP_Text score;
    public TMPro.TMP_Text dodo;
    public int allEggs;
    public int collectedEggs;
    public bool dodoSaved;


    public void Display()
    {
        allEggs = eggs.AmountOfAllExisting;
        collectedEggs = eggs.collectedEggs;
        dodoSaved = cage.birdSaved;


        UI.SetActive(true);
        score.text = collectedEggs.ToString() + " / " + allEggs.ToString();
        if (dodoSaved)
            dodo.text = "Found";
        else
            dodo.text = "Not Found";
        
    }
    public void NextLevel()
    {
        StartCoroutine(Loading());
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadMenu()
    {
        StartCoroutine(Loading());
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    IEnumerator Loading()
    {
        crossfade.GetComponent<Animator>().SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("DONE");
    }
}
