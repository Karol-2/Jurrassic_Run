using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Screen : MonoBehaviour
{
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private AudioClip gameoverSound;

    private void Awake()
    {
        gameoverScreen.SetActive(false);
    }
    public void GameOver()
    {
        gameoverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameoverSound);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
