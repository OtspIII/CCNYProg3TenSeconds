using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    Bar player;

    void Start(){
        player = GameObject.Find("Bar").GetComponent<Bar>();
    }

    void Update()
    {
        transform.position = bar.transform.position;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Win"){
            player.canWin = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Win"){
            player.canWin = false;
        }
    }
}
