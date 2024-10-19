using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cool_text_Neo : MonoBehaviour
{
    public string entered;
    public TextMeshProUGUI[] prompt;
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
    public TextMeshProUGUI prompt11;

    int o;
    int word;

    private void Start()
    {
        word = Random.Range(0, 7);
        if (word == 0)
        {
            additoinal();
        }
    }
    /*
     * discovery
invisible
dispelled
additional
instantiate
explosio*/
    void additoinal()
    {
        prompt[0].text = "a";
        prompt[0].transform.localPosition = new Vector2(-485.28f, -83);
        prompt[1].text = "d";
        prompt[2].text = "d";
        prompt[3].text = "i";
        prompt[4].text = "t";
        prompt[5].text = "o";
        prompt[6].text = "i";
        prompt[7].text = "n";
        prompt[8].text = "a";
        prompt[9].text = "l";
    }
    void Update()
    {
        Debug.Log(o);
        if (Input.inputString != "")
        {
            if (prompt[o].text == Input.inputString)
            {
                prompt[o].color = new Color(30, 200, 40);
                o++;
            }
            else 
            {
                for(; o >= 0; o--)
                {
                    prompt[o].color = new Color(0, 0, 0);
                }
                o = 0;
            }
        }
    }
     
}
