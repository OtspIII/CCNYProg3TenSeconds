using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KyleSpin : MonoBehaviour
{
    public SpriteRenderer armSprite;
    public float spinDegree;
    public float perSpinDegree;
    public char currentWASD;

    public TextMeshProUGUI currentWASDText;
    public TextMeshProUGUI currentDegreeText;

    private void Update()
    {
        currentWASDText.text = currentWASD.ToString();
        currentDegreeText.text = spinDegree.ToString();

        if (Input.GetKeyDown(KeyCode.W) && currentWASD == 'W')
        {
            Debug.Log("WWWWWWWWWWWWW");
            spinDegree += perSpinDegree;
            currentWASD = 'A';
        }
        if (Input.GetKeyDown(KeyCode.A) && currentWASD == 'A')
        {
            Debug.Log("AAAAAAAAAAAA");
            spinDegree += perSpinDegree;
            currentWASD = 'S';
        }
        if (Input.GetKeyDown(KeyCode.S) && currentWASD == 'S')
        {
            Debug.Log("S");
            spinDegree += perSpinDegree;
            currentWASD = 'D';
        }
        if (Input.GetKeyDown(KeyCode.D) && currentWASD == 'D')
        {
            Debug.Log("D");
            spinDegree += perSpinDegree;
            currentWASD = 'W';
        }
    }
}
