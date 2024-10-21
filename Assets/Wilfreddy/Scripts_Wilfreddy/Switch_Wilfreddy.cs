using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Wilfreddy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Switching());
    }

    IEnumerator Switching()
    {
        yield return new WaitForSeconds(.5f);
        GameMaster.NextStage();
    }
}
