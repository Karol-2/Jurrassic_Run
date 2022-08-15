using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Respawn playerRespawn;

    [Header("Health Bars")]
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    [Header("Number of Lives")]
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
