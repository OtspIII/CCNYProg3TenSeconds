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

    void Start()
    {
        UpdateUI();
    }

    public void UpdateHealth(int amount)
    {
        health += amount; 
        if (health < 0) health = 0; 

        ResetCombo(); 
        UpdateUI(); 
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
}

