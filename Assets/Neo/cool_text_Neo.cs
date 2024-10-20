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

    List<int> words = new List<int>();

    int o;
    int word;

    private void Start()
    {
        words.Add(0);
        words.Add(1);
        words.Add(2);
        word = Random.Range(0, words.Count);
        Debug.Log(word);
        if (word == 0)
        {
            additoinal();
        }
        else if (word == 1)
        {
            dicsovery();
        }
        else if (word == 2)
        {
            invislbie();
        }
    }
    /*
     * 

dispelled
additional
instantiate
explosio
    necromancy*/
    void additoinal()
    {
        prompt[0].text = "a";
        prompt[0].transform.localPosition = new Vector2(-485.28f, -83);
        prompt[1].text = "d";
        prompt[1].transform.localPosition = new Vector2(-349.4f, -83);
        prompt[2].text = "d";
        prompt[2].transform.localPosition = new Vector2(-210, -83);
        prompt[3].text = "i";
        prompt[3].transform.localPosition = new Vector2(-107, -83);
        prompt[4].text = "t";
        prompt[4].transform.localPosition = new Vector2(-17.6f, -83);
        prompt[5].text = "o";
        prompt[5].transform.localPosition = new Vector2(100.8f, -83);
        prompt[6].text = "i";
        prompt[6].transform.localPosition = new Vector2(196.4f, -83);
        prompt[7].text = "n";
        prompt[7].transform.localPosition = new Vector2(292, -83);
        prompt[8].text = "a";
        prompt[8].transform.localPosition = new Vector2(420.4f, -83);
        prompt[9].text = "l";
        prompt[9].transform.localPosition = new Vector2(519.1f, -83);
        prompt[10].text = "";
        words.Remove(0);
    }
    void dicsovery()
    {
        prompt[0].text = "d";
        prompt[0].transform.localPosition = new Vector2(-461.4f, -83);
        prompt[1].text = "i";
        prompt[1].transform.localPosition = new Vector2(-358.52f, -83);
        prompt[2].text = "c";
        prompt[2].transform.localPosition = new Vector2(-264.14f, -83);
        prompt[3].text = "s";
        prompt[3].transform.localPosition = new Vector2(-145.7f, -83);
        prompt[4].text = "o";
        prompt[4].transform.localPosition = new Vector2(-25, -83);
        prompt[5].text = "v";
        prompt[5].transform.localPosition = new Vector2(95.2f, -83);
        prompt[6].text = "e";
        prompt[6].transform.localPosition = new Vector2(219.3f, -83);
        prompt[7].text = "r";
        prompt[7].transform.localPosition = new Vector2(342.9f, -83);
        prompt[8].text = "y";
        prompt[8].transform.localPosition = new Vector2(465.7f, -83);
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove(1);
    }
    void invislbie()
    {
        prompt[0].text = "i";
        prompt[0].transform.localPosition = new Vector2(-413.8f, -83);
        prompt[1].text = "n";
        prompt[1].transform.localPosition = new Vector2(-318.34f, -83);
        prompt[2].text = "v";
        prompt[2].transform.localPosition = new Vector2(-198.4f, -83);
        prompt[3].text = "i";
        prompt[3].transform.localPosition = new Vector2(-107.24f, -83);
        prompt[4].text = "s";
        prompt[4].transform.localPosition = new Vector2(-16.2f, -83);
        prompt[5].text = "l";
        prompt[5].transform.localPosition = new Vector2(74.3f, -83);
        prompt[6].text = "b";
        prompt[6].transform.localPosition = new Vector2(177.22f, -83);
        prompt[7].text = "i";
        prompt[7].transform.localPosition = new Vector2(281, -83);
        prompt[8].text = "e";
        prompt[8].transform.localPosition = new Vector2(381, -83);
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove(2);
    }
    void Update()
    {
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
        if (prompt[o].text == "")
            Debug.Log("heeeeeeeeeeeeeeeeeeeeeeeeeeeeelp");
    }
     
}
