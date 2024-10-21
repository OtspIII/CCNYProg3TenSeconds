using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Wilfreddy : MonoBehaviour
{

    // Public variable to access the "Start" button in the UI

    public GameObject startButton;

    public GameObject seeStart;

    public GameObject text;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        seeStart.SetActive(true);

        text.SetActive(true);
        // Freeze the game at the start

    }



    // Function called when the "Start" button is pressed

    public void StartGame()
    {

        // Unfreeze the game

        Time.timeScale = 1;

        seeStart.SetActive(false);

        text.SetActive(false);

    }

}
