using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscene_rey : MonoBehaviour
{
    float endthreshold;
    float endelapsedTime;

    //public TextMeshProUGUI txt;

    private void Start()
    {
        endelapsedTime = 0f;
        endthreshold = 9f;
    }

    private void Update()
    {
        endelapsedTime += Time.deltaTime;

        if (endelapsedTime > endthreshold)
        {
            
            GameMaster.NextStage();
        }
    }
}
