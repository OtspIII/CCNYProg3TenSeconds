using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ClickManager : MonoBehaviour
{
    public GameObject Title;
    public Image CountdownBar;
    public TextMeshProUGUI CountdownText;

    public GameObject targetPrefab;
    public int score;
    public TextMeshProUGUI Score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleCountdown());
        StartCoroutine(GameCountdown());
        score = 0;
        Vector3 newPos = new Vector3(Random.Range(-7.9f, 7.9f), Random.Range(-4f, 4f), 0f);
        GameObject newEnemy = Instantiate(targetPrefab, newPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = score.ToString() + " / 15";
        if (score >= 15)
        {
            Win();
        }
    }

    public IEnumerator TitleCountdown()
    {
        yield return new WaitForSeconds(1);
        Title.SetActive(false);
    }

    public IEnumerator GameCountdown()
    {
        float timeRemaining = 10f;

        while (timeRemaining > 0)
        {
            CountdownText.text = Mathf.Ceil(timeRemaining).ToString();
            CountdownBar.fillAmount = timeRemaining / 10f;

            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        CountdownText.text = "0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Hit()
    {
        Vector3 newPos = new Vector3(Random.Range(-7.9f, 7.9f), Random.Range(-4f, 4f), 0f);
        GameObject newEnemy = Instantiate(targetPrefab, newPos, Quaternion.identity);
        score++;
    }

    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
