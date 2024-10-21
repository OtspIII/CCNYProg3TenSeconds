using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingGame : MonoBehaviour {
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI timerText;
    public int startTime = 10;
    public Color correctColor = Color.green;
    public Color loseColor = Color.red;
    public float freezeDuration = 1f;

    private string targetString = "Type the text on the screen!!!";
    private int currentIndex = 0;
    private float timeRemaining;
    private bool isTypingTimer = false;
    private string currentTimerText = "";
    private bool isGameActive = true;

    void Start() {
        ResetGame();
    }

    void ResetGame() {
        currentIndex = 0;
        timeRemaining = startTime;
        isTypingTimer = false;
        isGameActive = true;
        UpdateTargetText();
        UpdateTimerDisplay();
    }

    void Update() {
        if (!isGameActive) return;

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();

            if (Input.anyKeyDown) {
                foreach (char c in Input.inputString) {
                    if (!isTypingTimer) {
                        ProcessTargetStringInput(c);
                    }
                    else {
                        ProcessTimerInput(c);
                    }
                }
            }
            
            while (currentIndex < targetString.Length && targetString[currentIndex] == ' ') {
                currentIndex++;
                UpdateTargetText();
            }
        }
        else {
            GameOver();
        }
    }

    void ProcessTargetStringInput(char c) {
        if (c == targetString[currentIndex]) {
            currentIndex++;
            UpdateTargetText();

            if (currentIndex == targetString.Length) {
                isTypingTimer = true;
                currentIndex = 0;
            }
        }
    }

    void ProcessTimerInput(char c) {
        if (c == currentTimerText[currentIndex]) {
            currentIndex++;
            UpdateTimerText();

            if (currentIndex == currentTimerText.Length) {
                WinGame();
            }
        }
    }

    void UpdateTimerDisplay() {
        int remainingSeconds = Mathf.Max(0, Mathf.CeilToInt(timeRemaining));
        currentTimerText = remainingSeconds.ToString();
        timerText.text = currentTimerText;
    }

    void UpdateTargetText() {
        string coloredText = "";
        for (int i = 0; i < targetString.Length; i++) {
            if (i < currentIndex) {
                coloredText += $"<color=#{ColorUtility.ToHtmlStringRGB(correctColor)}>{targetString[i]}</color>";
            }
            else {
                coloredText += targetString[i];
            }
        }
        targetText.text = coloredText;
    }

    void UpdateTimerText() {
        string coloredText = "";
        for (int i = 0; i < currentTimerText.Length; i++) {
            if (i < currentIndex) {
                coloredText += $"<color=#{ColorUtility.ToHtmlStringRGB(correctColor)}>{currentTimerText[i]}</color>";
            }
            else {
                coloredText += currentTimerText[i];
            }
        }
        timerText.text = coloredText;
    }

    void WinGame() {
        isGameActive = false;
        Debug.Log("You win!");
    }

    void GameOver() {
        isGameActive = false;
        StartCoroutine(GameOverSequence());
    }

    IEnumerator GameOverSequence() {
        Debug.Log("Game Over!");
        
        SetAllTextRed();
        yield return new WaitForSeconds(freezeDuration);
        ResetGame();
    }

    void SetAllTextRed() {
        targetText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(loseColor)}>{targetString}</color>";
        timerText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(loseColor)}>{currentTimerText}</color>";
    }
}