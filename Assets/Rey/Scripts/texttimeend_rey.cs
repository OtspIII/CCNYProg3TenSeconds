using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class texttimeend_rey : MonoBehaviour
{
    float GOendthreshold;
    float GOendelapsedTime;

    public TextMeshProUGUI showtext;

    //public TextMeshProUGUI txt;

    private void Start()
    {
        GOendelapsedTime = 0f;
        GOendthreshold = 3f;
    }

    private void Update()
    {
        GOendelapsedTime += Time.deltaTime;

        if (GOendelapsedTime > GOendthreshold)
        {
            
            GameMaster.NextStage();
        }

        double b = System.Math.Round(GOendelapsedTime);
        showtext.text = b.ToString();
    }
}
