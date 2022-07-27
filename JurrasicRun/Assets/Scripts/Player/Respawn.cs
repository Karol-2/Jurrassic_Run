using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip failureSound;
    public int amountOfLives = 2;
    private Transform currenCheckpoint;
    private Health playerHealth;
    [SerializeField] private Death_Screen deathScreen;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        deathScreen = FindObjectOfType<Death_Screen>();
    }

    public void CheckRespawn()
    {

        if (currenCheckpoint == null || amountOfLives <1)
        {
            SoundManager.instance.PlaySound(failureSound);
            deathScreen.GameOver();

            return;
        }

        transform.position = currenCheckpoint.position;
        amountOfLives -= 1;
        playerHealth.Respawn();

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Checkpoint"))
        {
            currenCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
