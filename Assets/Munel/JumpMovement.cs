using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    float jumpheight = 10f;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && transform.position.y < -2.5)
        {
            playerRB.AddForce(Vector3.up * jumpheight, ForceMode2D.Impulse);
        }
    }
}