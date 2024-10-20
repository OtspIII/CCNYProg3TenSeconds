using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for the game


    bool grounded;
    public LayerMask groundLayer;
    public Vector2 boxSize;
    public float castDistance;
    public float speed;
    public float jump;
    private float Move;

    Rigidbody2D rb;     //place to store the rigidbody of the object

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();   //store the rb of the object
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
   
}