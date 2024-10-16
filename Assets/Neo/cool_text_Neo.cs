using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cool_text_Neo : MonoBehaviour
{
    public string entered;
    public TextMeshProUGUI prompt;
    public TextMeshProUGUI prompt1;
    public TextMeshProUGUI prompt2;
    public TextMeshProUGUI prompt3;
    public TextMeshProUGUI prompt4;
    public TextMeshProUGUI prompt5;
    public TextMeshProUGUI prompt6;
    public TextMeshProUGUI prompt7;
    public TextMeshProUGUI prompt8;
    public TextMeshProUGUI prompt9;
    public TextMeshProUGUI prompt10;

    public List<TextMeshProUGUI> word = new List<TextMeshProUGUI>();
    private void Start()
    {
        word.Add(prompt1);
        word.Add(prompt2);
        word.Add(prompt3);
        word.Add(prompt4);
        word.Add(prompt5);
        word.Add(prompt6);
        word.Add(prompt7);
        word.Add(prompt8);
        word.Add(prompt9);
        word.Add(prompt10);
    }
    void Update()
    {
        if (Input.inputString != "")
        {
            if (word[0].text == Input.inputString)
            {
                word[0].color = new Color(0, 0, 4);
                word.Remove(word[0]);
            }
        }
             entered += Input.inputString;
        prompt.text = entered;
    }
     
}
