using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class KyleSpin : MonoBehaviour
{
    public SpriteRenderer armSprite;
    public float spinDegree;
    public float perSpinDegree;
    public char currentWASD;

    public TextMeshProUGUI currentWASDText;
    public TextMeshProUGUI currentDegreeText;

    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;

    public Image bg;

    private void Update()
    {
        currentWASDText.text = currentWASD.ToString();
        currentDegreeText.text = "Cranks Left: " + ((7200 - spinDegree)/360).ToString();

        if (Input.GetKeyDown(KeyCode.W) && currentWASD == 'W')
        {
            bg.sprite = bg1;
            spinDegree += perSpinDegree;
            currentWASD = 'A';
        }
        if (Input.GetKeyDown(KeyCode.A) && currentWASD == 'A')
        {
            bg.sprite = bg2;
            spinDegree += perSpinDegree;
            currentWASD = 'S';
        }
        if (Input.GetKeyDown(KeyCode.S) && currentWASD == 'S')
        {
            bg.sprite = bg3;
            spinDegree += perSpinDegree;
            currentWASD = 'D';
        }
        if (Input.GetKeyDown(KeyCode.D) && currentWASD == 'D')
        {
            bg.sprite = bg4;
            spinDegree += perSpinDegree;
            currentWASD = 'W';
        }

        if (((7200 - spinDegree) / 360) < 0)
            GameMaster.NextStage();
    }
}
