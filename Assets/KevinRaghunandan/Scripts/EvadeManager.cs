using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvadeManager : MonoBehaviour
{
    public GameObject Title;
    public Image CountdownBar;
    public TextMeshProUGUI CountdownText;

    public GameObject myPlayer;
    float playerHealthCount;
    public Image HealthBar;
    public TextMeshProUGUI HealthText;

    public GameObject enemyPrefab;
    bool enemySpawned;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleCountdown());
        StartCoroutine(GameCountdown());
        enemySpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthCount = myPlayer.GetComponent<PlayerController>().myHealth;
        HealthText.text = playerHealthCount.ToString();
        HealthBar.fillAmount = playerHealthCount / 3f;

        if (enemySpawned)
        {
            StartCoroutine(enemySpawn(1f));
        }

        if (playerHealthCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        Win();
    }

    private IEnumerator enemySpawn(float waitTime)
    {
        enemySpawned = false;

        Vector3 newPos = new Vector3(Random.Range(-7.9f, 7.9f), Random.Range(-4f, 4f), 0f);
        GameObject newEnemy = Instantiate(enemyPrefab, newPos, Quaternion.identity);
        newEnemy.name = "Enemy";

        yield return new WaitForSeconds(waitTime);

        enemySpawned = true;
    }

    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}