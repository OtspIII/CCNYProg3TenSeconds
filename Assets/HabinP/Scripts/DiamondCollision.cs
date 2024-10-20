using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class DiamondCollision : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI DescriptionText;
    bool hasCollided = false;


    private float timeLeft = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = Mathf.Round(timeLeft).ToString();

        timeLeft = 10 - Time.timeSinceLevelLoad;

        if(timeLeft < 0)
        {
            DescriptionText.text = "Game Over, Press R to try again";
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            //load active scene with scenemanager
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    //on trigger enter 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlueWire" & !hasCollided)
        {
            hasCollided = true;
            DescriptionText.text = "You defused the bomb, Game Won, Press R to try again";
            Time.timeScale = 0;

        }
        if (collision.gameObject.tag == "RedWire" & !hasCollided)
        {
            hasCollided = true;
            DescriptionText.text = "Bomb Exploded, Press R to try again";
            Time.timeScale = 0;

        }
        if (collision.gameObject.tag == "YellowWire" & !hasCollided)
        {
            hasCollided = true;
            DescriptionText.text = "Bomb Exploded, Press R to try again";
            Time.timeScale = 0;

        }
    }
}
