using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public Canvas screen;

    private float countdownTime = 10f;
    private bool timerActive = true;

    public SpriteRenderer Fader;
    public GameObject spawner;
    public GameObject window;


    void Start()
    {
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

     private void DestroyObjectsByTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }


    private IEnumerator PauseGame(float pauseDuration)
    {       
        window.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        DestroyObjectsByTag("HitObject");
        DestroyObjectsByTag("SpinObject");
        DestroyObjectsByTag("DuckObject");

        Time.timeScale = 0; 
        yield return new WaitForSecondsRealtime(pauseDuration); 
        Time.timeScale = 1; 
        screen.gameObject.SetActive(false);


        yield return StartCoroutine(GameMaster.Fade(Fader, true, 0.5f));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //testing

        GameMaster.NextStage();
    }
}

