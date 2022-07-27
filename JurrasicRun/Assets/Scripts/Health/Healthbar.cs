using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Respawn playerRespawn;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    public TMPro.TMP_Text lives;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;

        lives.text = playerRespawn.amountOfLives.ToString() + "x";
    }
}
