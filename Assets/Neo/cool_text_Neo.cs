using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cool_text_Neo : MonoBehaviour
{
    public string entered;
    public TextMeshProUGUI[] prompt;

    public TextMeshProUGUI background;

    List<string> words = new List<string>();

    public SpriteRenderer yip1;
    public SpriteRenderer yip2;
    public SpriteRenderer yip3;

    public GameObject WIN;

    int o;
    int word;
    int stage;

    float timer = 0;
    bool flip;
    public GameObject logo;

    Color black = new Color(0, 0, 0);
    Color gray = new Color(0.8f, 0.8f, 0.8f);

    private void Start()
    {
        words.Add("additoinal");
        words.Add("dicsovery");
        words.Add("invislbie");
        words.Add("instnatiate");
        words.Add("exploshon");
        words.Add("diselled");
        words.Add("necromancey");
        Roll();
        StartCoroutine(FlashingLights());
        StartCoroutine(FlashingLetter());

    }
    void Roll()
    {
        word = Random.Range(0, words.Count);
        background.text = words[word];
        Debug.Log(words[word]);
        if (words[word] == "additoinal")
        {
            Additoinal();
        }
        else if (words[word] == "dicsovery")
        {
            Dicsovery();
        }
        else if (words[word] == "invislbie")
        {
            Invislbie();
        }
        else if (words[word] == "instnatiate")
        {
            Instnatiate();
        }
        else if (words[word] == "exploshon")
        {
            Exploshon();
        }
        else if (words[word] == "diselled")
        {
            Diselled();
        }
        else if (words[word] == "necromancey")
        {
            Necromancey();
        }
    }
    void Additoinal()
    {
        prompt[0].text = "a";
        prompt[0].transform.localPosition = new Vector2(-485.28f, -28);
        prompt[1].text = "d";
        prompt[1].transform.localPosition = new Vector2(-349.4f, -28);
        prompt[2].text = "d";
        prompt[2].transform.localPosition = new Vector2(-210, -28);
        prompt[3].text = "i";
        prompt[3].transform.localPosition = new Vector2(-107, -28);
        prompt[4].text = "t";
        prompt[4].transform.localPosition = new Vector2(-17.6f, -28);
        prompt[5].text = "o";
        prompt[5].transform.localPosition = new Vector2(100.8f, -28);
        prompt[6].text = "i";
        prompt[6].transform.localPosition = new Vector2(196.4f, -28);
        prompt[7].text = "n";
        prompt[7].transform.localPosition = new Vector2(292, -28);
        prompt[8].text = "a";
        prompt[8].transform.localPosition = new Vector2(420.4f, -28);
        prompt[9].text = "l";
        prompt[9].transform.localPosition = new Vector2(519.1f, -28);
        prompt[10].text = "";
        words.Remove("additoinal");
    }
    void Dicsovery()
    {
        prompt[0].text = "d";
        prompt[0].transform.localPosition = new Vector2(-461.4f, -28);
        prompt[1].text = "i";
        prompt[1].transform.localPosition = new Vector2(-358.52f, -28);
        prompt[2].text = "c";
        prompt[2].transform.localPosition = new Vector2(-264.14f, -28);
        prompt[3].text = "s";
        prompt[3].transform.localPosition = new Vector2(-145.7f, -28);
        prompt[4].text = "o";
        prompt[4].transform.localPosition = new Vector2(-25, -28);
        prompt[5].text = "v";
        prompt[5].transform.localPosition = new Vector2(95.2f, -28);
        prompt[6].text = "e";
        prompt[6].transform.localPosition = new Vector2(219.3f, -28);
        prompt[7].text = "r";
        prompt[7].transform.localPosition = new Vector2(342.9f, -28);
        prompt[8].text = "y";
        prompt[8].transform.localPosition = new Vector2(465.7f, -28);
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove("dicsovery");
    }
    void Invislbie()
    {
        prompt[0].text = "i";
        prompt[0].transform.localPosition = new Vector2(-413.8f, -28);
        prompt[1].text = "n";
        prompt[1].transform.localPosition = new Vector2(-318.34f, -28);
        prompt[2].text = "v";
        prompt[2].transform.localPosition = new Vector2(-198.4f, -28);
        prompt[3].text = "i";
        prompt[3].transform.localPosition = new Vector2(-107.24f, -28);
        prompt[4].text = "s";
        prompt[4].transform.localPosition = new Vector2(-16.2f, -28);
        prompt[5].text = "l";
        prompt[5].transform.localPosition = new Vector2(74.3f, -28);
        prompt[6].text = "b";
        prompt[6].transform.localPosition = new Vector2(177.22f, -28);
        prompt[7].text = "i";
        prompt[7].transform.localPosition = new Vector2(281, -28);
        prompt[8].text = "e";
        prompt[8].transform.localPosition = new Vector2(381, -28);
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove("invislbie");
    }
    void Instnatiate()
    {
        prompt[0].text = "i";
        prompt[0].transform.localPosition = new Vector2(-582.46f, -28);
        prompt[1].text = "n";
        prompt[1].transform.localPosition = new Vector2(-486, -28);
        prompt[2].text = "s";
        prompt[2].transform.localPosition = new Vector2(-366.6f, -28);
        prompt[3].text = "t";
        prompt[3].transform.localPosition = new Vector2(-252.5f, -28);
        prompt[4].text = "n";
        prompt[4].transform.localPosition = new Vector2(-133.8f, -28);
        prompt[5].text = "a";
        prompt[5].transform.localPosition = new Vector2(-5.5f, -28);
        prompt[6].text = "t";
        prompt[6].transform.localPosition = new Vector2(116.1f, -28);
        prompt[7].text = "i";
        prompt[7].transform.localPosition = new Vector2(205.1f, -28);
        prompt[8].text = "a";
        prompt[8].transform.localPosition = new Vector2(304.8f, -28);
        prompt[9].text = "t";
        prompt[9].transform.localPosition = new Vector2(426.2f, -28);
        prompt[10].text = "e";
        prompt[10].transform.localPosition = new Vector2(548.7f, -28);
        prompt[10].transform.localPosition = new Vector2(548.7f, -28);
        words.Remove("instnatiate");
    }
    void Exploshon()
    {
        prompt[0].text = "e";
        prompt[0].transform.localPosition = new Vector2(-479.87f, -28);
        prompt[1].text = "x";
        prompt[1].transform.localPosition = new Vector2(-343.4f, -28);
        prompt[2].text = "p";
        prompt[2].transform.localPosition = new Vector2(-209.5f, -28);
        prompt[3].text = "l";
        prompt[3].transform.localPosition = new Vector2(-113.7f, -28);
        prompt[4].text = "o";
        prompt[4].transform.localPosition = new Vector2(-18.6f, -28);
        prompt[5].text = "s";
        prompt[5].transform.localPosition = new Vector2(102, -28);
        prompt[6].text = "h";
        prompt[6].transform.localPosition = new Vector2(228.6f, -28);
        prompt[7].text = "o";
        prompt[7].transform.localPosition = new Vector2(359.6f, -28);
        prompt[8].text = "n";
        prompt[8].transform.localPosition = new Vector2(484, -28);
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove("exploshon");
    }
    void Diselled()
    {
        prompt[0].text = "d";
        prompt[0].transform.localPosition = new Vector2(-358.79f, -28);
        prompt[1].text = "i";
        prompt[1].transform.localPosition = new Vector2(-255.6f, -28);
        prompt[2].text = "s";
        prompt[2].transform.localPosition = new Vector2(-164.5f, -28);
        prompt[3].text = "e";
        prompt[3].transform.localPosition = new Vector2(-40.4f, -28);
        prompt[4].text = "l";
        prompt[4].transform.localPosition = new Vector2(58.6f, -28);
        prompt[5].text = "l";
        prompt[5].transform.localPosition = new Vector2(124.2f, -28);
        prompt[6].text = "e";
        prompt[6].transform.localPosition = new Vector2(222.6f, -28);
        prompt[7].text = "d";
        prompt[7].transform.localPosition = new Vector2(359, -28);
        prompt[8].text = "";
        prompt[9].text = "";
        prompt[10].text = "";
        words.Remove("diselled");
    }
    void Necromancey()
    {
        prompt[0].text = "n";
        prompt[0].transform.localPosition = new Vector2(-660.48f, -28);
        prompt[1].text = "e";
        prompt[1].transform.localPosition = new Vector2(-532.2f, -28);
        prompt[2].text = "c";
        prompt[2].transform.localPosition = new Vector2(-404.3f, -28);
        prompt[3].text = "r";
        prompt[3].transform.localPosition = new Vector2(-286.4f, -28);
        prompt[4].text = "o";
        prompt[4].transform.localPosition = new Vector2(-166.5f, -28);
        prompt[5].text = "m";
        prompt[5].transform.localPosition = new Vector2(-11.7f, -28);
        prompt[6].text = "a";
        prompt[6].transform.localPosition = new Vector2(146.5f, -28);
        prompt[7].text = "n";
        prompt[7].transform.localPosition = new Vector2(274.3f, -28);
        prompt[8].text = "c";
        prompt[8].transform.localPosition = new Vector2(397.7f, -28);
        prompt[9].text = "e";
        prompt[9].transform.localPosition = new Vector2(524.8f, -28);
        prompt[10].text = "y";
        prompt[10].transform.localPosition = new Vector2(657.2f, -28);
        words.Remove("necromancey");
    }
    void Update()
    {
        if (Input.inputString != "")
        {
            if (prompt[o].text == Input.inputString.ToString().ToLower())
            {
                if (WIN.active == false)
                {
                    prompt[o].color = new Color(1, 0.3f, 1);
                    o++;
                }
            }
            else
            {
                for (; o >= 0; o--)
                {
                    prompt[o].color = new Color(0, 0, 0);
                }
                o = 0;
            }
        }
        if (prompt[o].text == "")
        {
            /*
            if (stage == 0)
            {
                yip1.color = new Color(1, 1, 1);
                stage++;
            }
            else if (stage == 1)
            {
                yip2.color = new Color(1, 1, 1);
                stage++;
            }
            else if (stage == 2)
            {
                yip3.color = new Color(1, 1, 1);
                stage++;
            }
            if (stage < 3)
            {*/
                o = 0;
            
                Roll();
                for (int i = 0; i < prompt.Length; i++)
                {
                    prompt[i].color = black;
                }
            //}
            //else
            //{
                WIN.SetActive(true);
            //}
        }
    }
    public IEnumerator FlashingLights()
    {
        while (true)
        {

            timer += Time.deltaTime*5;
            if (!flip)
                logo.transform.localScale = new Vector2(Mathf.Lerp(0.6f, 0.72f, timer), Mathf.Lerp(0.6f, 0.72f, timer));
            
            if (flip)
                logo.transform.localScale = new Vector2(Mathf.Lerp(0.72f, 0.6f, timer), Mathf.Lerp(0.72f, 0.6f, timer));

            if (logo.transform.localScale.x > 0.71f && flip == false)
            {
                flip = true;
                timer = 0;
            }

            if (logo.transform.localScale.x < 0.61f && flip == true)
            {
                flip = false;
                timer = 0;
            }
            yield return null;
        }
    }
    public IEnumerator FlashingLetter()
    {
        while (o == 0)
        {
            if (prompt[0].color == black)
            {
                prompt[0].color = gray;
                yield return new WaitForSeconds(0.25f);
            }
            if (prompt[0].color == gray)
            {
                prompt[0].color = black;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
