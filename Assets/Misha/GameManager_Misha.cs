using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_Misha : MonoBehaviour
{
    public bool UseCoroutine;

    public TextMeshPro Countdown;
    public SpriteRenderer Fader;
    
    public float Timer = 3;

    void Start()
    {
        if (UseCoroutine) StartCoroutine(CoroutineCountdown());
    }
    
    void Update()
    {
        if (UseCoroutine) return;

        Timer -= Time.deltaTime;
        Countdown.text = Mathf.Ceil(Timer).ToString();
        if (Timer <= 0)
        {
            GameMaster.NextStage();
        }
    }

    public IEnumerator CoroutineCountdown()
    {
        Countdown.text = "Hit Space";
        yield return StartCoroutine(GameMaster.Fade(Fader, false, 0.5f));
        while (!Input.GetKeyDown(KeyCode.Space)) yield return null;
        Countdown.text = "3";
        yield return new WaitForSeconds(1);
        Countdown.text = "2";
        yield return new WaitForSeconds(1);
        Countdown.text = "1";
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(GameMaster.Fade(Fader, true, 0.5f));
        GameMaster.NextStage();
    }
}
