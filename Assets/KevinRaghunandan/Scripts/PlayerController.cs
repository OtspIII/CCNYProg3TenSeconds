using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float deceleration = 0.95f;
    public SpriteRenderer mySprite;
    public float myHealth = 3;

    Rigidbody2D myBody;
    Vector3 previousPos;
    Vector3 targetDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        myBody = this.gameObject.GetComponent<Rigidbody2D>();
        mySprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            targetDir += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetDir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetDir += Vector3.right;
        }

        previousPos = this.gameObject.transform.position;
    }

    void FixedUpdate()
    {
        myBody.AddForce(targetDir, ForceMode2D.Impulse);
        myBody.velocity = deceleration * myBody.velocity;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy")
        {
            StartCoroutine(itsBeenHit(.2f));
        }
    }

    private IEnumerator itsBeenHit(float waitTime)
    {
        mySprite.color = Color.red;
        myHealth -= 1;
        yield return new WaitForSeconds(waitTime);
        mySprite.color = Color.blue;
    }
}
