using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_Neo : MonoBehaviour
{
    float timer = 0;
    public GameObject timerObj;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MySexyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        MySexyCoroutine();
        Debug.Log("yip1");
    }

    public IEnumerator MySexyCoroutine()
    {
        //timer -= 1;
        //yield return new WaitForSeconds(1);
        while (timer < 1)
        {
            Debug.Log("yip");
            timer += Time.deltaTime / 10f;

            timerObj.transform.localScale = new Vector2(Mathf.Lerp(38.38f, 0, timer), 1);

            yield return null;
        }
        GameMaster.NextStage();
    }
}
