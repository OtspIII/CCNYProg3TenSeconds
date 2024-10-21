using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_Wilfreddy : MonoBehaviour
{

    public GameObject ExplosionSound;
    public GameObject Canvas;
    public GameObject ExplosionPNG;

    public GameObject Bomb;
    

    float currentTime;
    public float startingTime = 10f;

    [SerializeField] Text countdownText;
    void Start()
    {
        ExplosionSound.SetActive(false);
        Canvas.SetActive(false);
        ExplosionPNG.SetActive(false);


        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            ExplosionSound.SetActive(true);
            Canvas.SetActive(true);
            ExplosionPNG.SetActive(true);

            Bomb.SetActive(false);
            

            StartCoroutine(Switching());
        }
    }

    IEnumerator Switching()
    {
        yield return new WaitForSeconds(6f);
        GameMaster.NextStage();

    }
}
