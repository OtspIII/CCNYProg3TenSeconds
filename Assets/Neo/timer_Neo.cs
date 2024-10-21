using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_Neo : MonoBehaviour
{
    float timer = 0;
    float timer2 = 0;
    public GameObject timerObj;

    public GameObject WIN;

    public TextMeshProUGUI lose;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MySexyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        MySexyCoroutine();
    }

    public IEnumerator MySexyCoroutine()
    {
        //timer -= 1;
        while (timer < 1)
        {
            
            timer += Time.deltaTime / 10f;

            timerObj.transform.localScale = new Vector2(Mathf.Lerp(38.38f, 0, timer), 1);

            yield return null;
            
            if (WIN.active == true)
            {
                timer = 3;
            }
        }
        if (timer < 3)
        {
            lose.text = "YOU LOST!";
            WIN.SetActive(true);

        }
        yield return new WaitForSeconds(2);
        GameMaster.NextStage();
    }
}
