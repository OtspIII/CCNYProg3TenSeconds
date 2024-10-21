using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject myPlayer;
    public float maxDistDelta = .01f;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 playerPos = myPlayer.transform.position;
        Vector3 targetPos = Vector3.Lerp(playerPos, this.transform.position, .5f);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, maxDistDelta);
    }
}
