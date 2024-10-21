using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
    Vector2 pos, objPos;
    float speed = 15.0f;
    [SerializeField] float leftWinBound, rightWinBound;
    public bool canWin;
    bool win, tapped, stop;
    [SerializeField] GameObject moveObj;
    [SerializeField] GameObject rabbit, rat;
    Collider2D col;
    float timer = 3.0f;
    void Start()
    {
        pos = transform.position;
        objPos = moveObj.transform.position;

        col = GameObject.Find("Red").GetComponent<Collider2D>();

        rabbit.SetActive(false);
        rat.SetActive(false);
    }

    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        moveObj.transform.position = objPos;

        MoveBar();

        if(Input.GetKeyDown(KeyCode.Space) && !tapped){
            tapped = true;
            stop = true;

            if(canWin){
                win = true;
            }
        }

        if(stop){
            timer -= Time.deltaTime;

            if(timer < 0){
                GameMaster.NextStage();
            }
        }
    }

    void MoveBar(){
        if(!stop){
            pos.x += speed * Time.deltaTime;
        }

        if(pos.x > 9.3f && speed > 0f){
            speed *= -1;
        } else if(pos.x < -4.5f && speed < 0f){
            speed *= -1;
        }

        WinGame();
    }

    void WinGame(){
        if(tapped){
            if(win){
                rabbit.SetActive(true);
            } else {
                rat.SetActive(true);
            }

            if(objPos.y < 1.6f){
                objPos.y += 10.0f * Time.deltaTime;
            } else {
                objPos.y = 1.6f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Win"){
            canWin = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Win"){
            canWin = false;
        }
    }
}
