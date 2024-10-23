using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer_rey : MonoBehaviour
{
    float threshold;
    float elapsedTime;

    private void Start()
    {
        elapsedTime = 0f;
        threshold = 1f;

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > threshold)
        {
            SceneManager.LoadScene(11);
        }


    }
}
