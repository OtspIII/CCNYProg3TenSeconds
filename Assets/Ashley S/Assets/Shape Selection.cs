using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShapeSelection : MonoBehaviour
{
    public ShapeSequence shapeSequence;
    public Button[] shapeButtons; 
    public TextMeshProUGUI selectionInstructionText;
    public TextMeshProUGUI successMessageText;
    public TextMeshProUGUI timerText;
    public Canvas gameCanvas;
    public Canvas sequenceCanvas;

    private List<int> correctSequence;
    private int currentStep = 0; // Tracks the current step in the sequence
    private int currentRound = 1; // Track the current round number
    private float timerDuration = 10f;
    private Coroutine timerCoroutine;

    private void Start()
    {
        for (int i = 0; i < shapeButtons.Length; i++)
        {
            int index = i;
            shapeButtons[i].onClick.AddListener(() => OnShapeButtonClicked(index));
        }

        StartNewRound();
    }

    public void StartNewRound()
    {
        ResetButtonColors(); // Resets button colors
        currentStep = 0;
        gameCanvas.enabled = false; // Hides the selection canvas initially
        sequenceCanvas.enabled = true; // Shows sequence canvas to displaying me shapes :]

        shapeSequence.StartSequence(currentRound); // Start a new sequence display based on the current round
        StartCoroutine(WaitForSequence());
    }

    private IEnumerator WaitForSequence()
    {
        yield return new WaitUntil(() => shapeSequence.SequenceComplete);

        correctSequence = shapeSequence.sequence;
        sequenceCanvas.enabled = false; // Hides sequence canvas
        gameCanvas.enabled = true; // Show selection canvas

        selectionInstructionText.text = "Now select the shapes in the correct order!";
        selectionInstructionText.gameObject.SetActive(true);

        // Timer
        timerCoroutine = StartCoroutine(StartTimer(timerDuration));
    }

    private IEnumerator StartTimer(float duration)
    {
        float timeRemaining = duration;
        while (timeRemaining > 0)
        {
            timerText.text = $"Time: {timeRemaining:F1}";
            timeRemaining -= Time.deltaTime; // countdown
            yield return null;
        }

        StartCoroutine(ShowErrorMessage("Time's up! Game Over"));
    }

    private void OnShapeButtonClicked(int shapeIndex)
    {
        if (correctSequence[currentStep] == shapeIndex)
        {
            StartCoroutine(FlashButtonColor(shapeButtons[shapeIndex], Color.green)); // Verde
            currentStep++;

            if (currentStep >= correctSequence.Count)
            {
                // Correct Sequence
                StopCoroutine(timerCoroutine); // Stop the timer
                StartCoroutine(ShowSuccessMessage($"Correct sequence! Round {currentRound} complete!"));
            }
        }
        else
        {
            // Wrong Sequence
            StartCoroutine(FlashButtonColor(shapeButtons[shapeIndex], Color.red)); // Flash red
            StopCoroutine(timerCoroutine); // Stop the timer
            StartCoroutine(ShowErrorMessage("Incorrect! Restarting game... "));
        }
    }

    private IEnumerator FlashButtonColor(Button button, Color flashColor)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color originalColor = buttonImage.color; 
        buttonImage.color = flashColor; // Set the button color to the flash color
        yield return new WaitForSeconds(0.5f); // Wait for half a second
        buttonImage.color = originalColor; // Reset to original color
    }

    private void ResetButtonColors()
    {
        foreach (Button button in shapeButtons)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = Color.white; // Reset back to og color
        }
    }

    private IEnumerator ShowSuccessMessage(string message)
    {
        selectionInstructionText.gameObject.SetActive(false);

        successMessageText.text = message;
        successMessageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        successMessageText.gameObject.SetActive(false); // Hide the message

        currentRound++;
        StartNewRound();
    }

    private IEnumerator ShowErrorMessage(string message)
    {
        selectionInstructionText.text = message;
        selectionInstructionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        selectionInstructionText.gameObject.SetActive(false);

        currentRound = 1; // Reset round number to 1
        StartNewRound(); // Restart the round
    }
}