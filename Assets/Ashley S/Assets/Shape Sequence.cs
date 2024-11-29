using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShapeSequence : MonoBehaviour
{
    public Image[] shapeImages; // Array of shape images
    public List<int> sequence; // List to store the order of shapes
    public TextMeshProUGUI sequenceInstructionText; // Text for instructions during sequence display
    public bool SequenceComplete { get; private set; } // To track sequence completion

    private int displayDuration = 2;
    private float hideDuration = 0.5f;

    private void Start()
    {
        foreach (var img in shapeImages)
        {
            img.gameObject.SetActive(false);
        }
        sequence = new List<int>();
        SequenceComplete = false;
    }

    public void StartSequence(int roundNumber)
    {
        SequenceComplete = false;
        sequence.Clear();

        // Determine the number of shapes to display based on the current round
        int numberOfShapes = 3 + (roundNumber - 1) / 2;

        //instruction text before starting display
        sequenceInstructionText.text = "Watch the sequence carefully!";
        StartCoroutine(DisplayShapes(numberOfShapes));
    }
    //AHHHHHHHHHHHHHHHHHHHHHHH ok
    private IEnumerator DisplayShapes(int numberOfShapes)
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < numberOfShapes; i++) //controls how many shapes to display
        {
            int randomIndex = Random.Range(0, shapeImages.Length);
            sequence.Add(randomIndex);

            // Show the selected shape
            shapeImages[randomIndex].gameObject.SetActive(true);
            yield return new WaitForSeconds(displayDuration);

            // Hide the shape after displaying
            shapeImages[randomIndex].gameObject.SetActive(false);
            yield return new WaitForSeconds(hideDuration);
        }

        // Set instruction text after the sequence is generated
        sequenceInstructionText.text = $"Remember the sequence of {sequence.Count} shapes!";
        SequenceComplete = true; 
        Debug.Log("Sequence: " + string.Join(", ", sequence));
    }
}