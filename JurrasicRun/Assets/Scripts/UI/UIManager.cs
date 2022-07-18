using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
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
        //SoundManager.instance.PlaySound(gameoverSound);

    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        //SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
