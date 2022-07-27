using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour
{
    [SerializeField] private Finished_Panel panel;
    [SerializeField] private AudioClip victorySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(victorySound);
            Time.timeScale = 0f;
            panel.Display();
        }
    }



}

