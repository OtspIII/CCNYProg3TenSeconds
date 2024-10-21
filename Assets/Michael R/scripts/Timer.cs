using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    void Update()
    {

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            SceneManager.LoadScene("Level 1");
        }
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 10);
        int seconds = Mathf.FloorToInt(remainingTime % 10);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}