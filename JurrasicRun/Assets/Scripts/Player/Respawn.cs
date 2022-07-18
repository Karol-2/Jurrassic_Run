using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currenCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {

        if (currenCheckpoint == null)
        {
            uiManager.GameOver();

            return;
        }

        transform.position = currenCheckpoint.position;
        playerHealth.Respawn();

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currenCheckpoint = collision.transform;
            //SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
