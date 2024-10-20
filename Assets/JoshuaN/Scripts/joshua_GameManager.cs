using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class joshua_GameManager : MonoBehaviour
{

    [Header("Player Stats")]
    public int health;
    public int combo;

    [Header("UI References")]
    public TextMeshProUGUI healthText; 
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI failText; 
    public TextMeshProUGUI passText; 
    public TextMeshProUGUI timerText;

    private float countdownTime = 10f;
    private bool timerActive = true;

    private GameManager_Misha gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager_Misha>();

        UpdateUI();
        StartCoroutine(Timer());
    }

    public void UpdateHealth(int amount)
    {
        health += amount; 
        if (health < 0) health = 0; 

        ResetCombo(); 
        UpdateUI(); 

        if (health <= 0)
        {
            timerActive = false;
            ToggleFailText(true);
        }
    }

    public void ResetCombo()
    {
        combo = 0; 
        UpdateUI();
    }

    public void UpdateCombo(int amount)
    {
        combo += amount; 
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health Remaining: " + health;
        }

        if (comboText != null)
        {
            comboText.text = "Combo: " + combo + "!!!";
        }
    }

    public IEnumerator Timer()
    {
        while (countdownTime > 0 && timerActive)
        {
            countdownTime -= Time.deltaTime;

            UpdateTimerText(countdownTime);

            yield return null; 
        }

        if (health > 0)
        {
            TogglePassText(true); 
            StartCoroutine(PauseGame(3f));
        }
        else
        {
            ToggleFailText(true); 
            StartCoroutine(PauseGame(3f));
        }

        UpdateTimerText(0);
    }

    private void UpdateTimerText(float timeRemaining)
    {
        if (timerText != null)
        {
            timerText.text = "Time Remaining: " + Mathf.Ceil(timeRemaining) + "s"; 
        }
    }

    private void ToggleFailText(bool state)
    {
        if (failText != null)
        {
            failText.gameObject.SetActive(state);
        }
    }

    private void TogglePassText(bool state)
    {
        if (passText != null)
        {
            passText.gameObject.SetActive(state);
        }
    }


    private IEnumerator PauseGame(float pauseDuration)
    {
        Time.timeScale = 0; 
        yield return new WaitForSecondsRealtime(pauseDuration); 
        Time.timeScale = 1; 

        StartCoroutine(gameManager.CoroutineCountdown());
    }
}

