using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ClawMovement : MonoBehaviour
{
    //make a variable for the speed of the claw left and right as well as variable for drop speed of the claw, and a variable for claw drop amount
    public float speed = 1.0f;
    public float dropSpeed = 1.0f;
    public float dropAmount = 1.0f;
    public float forceAmount = 10.0f;
    //variable for claw wire game object
    public GameObject clawWire;
    public GameObject claw;

    //wire starting position
    float BeginingWireSY = 0.85f;
    float BeginingWirePY = -0.5f;

    //wire starting position
    float EndWireSY = 7f;
    float EndWirePY = -3.5f;

    Vector3 BeginWirePosition = new Vector3(0, 4.0f, 0);
    Vector3 EndWirePosition = new Vector3(0, 0.7f, 0);

    Vector3 BeginWireScale = new Vector3(0.25f, 0.85f, 1);
    Vector3 EndWireScale = new Vector3(0.25f, 7f, 1);


    //diamond position
    Vector3 BeginDiamondPosition = new Vector3(0, 3.5f, 0);
    Vector3 EndDiamondPosition = new Vector3(0, -2.8f, 0);

    bool isDropping = false;


    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeginWirePosition.x = transform.position.x;
        EndWirePosition.x = transform.position.x;
        BeginDiamondPosition.x = transform.position.x;
        EndDiamondPosition.x = transform.position.x;


        if (!isDropping)
        {
            //move self left and right using delta time and speed variable also make it glide further after stopping controlled using arrow keys use add force 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            //on release of leftarrow key add force to self to glide further using force amount
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-forceAmount, 0, 0));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            //on release of rightarrow key add force to self to glide further using force amount
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(forceAmount, 0, 0));
            }
        }

        //if you press spacebar freeze movement for self
        if (Input.GetKeyDown(KeyCode.Space) & !isDropping)
        {
            isDropping = true;

            StartCoroutine(AnimationPosition());
            StartCoroutine(AnimationScale());
            StartCoroutine(AnimationDiamond());
        }

        IEnumerator AnimationPosition()
            {
            float time = 0.0f;
            while (time < 1)
            {
                clawWire.transform.position = Vector3.Lerp(BeginWirePosition, EndWirePosition, time);
                time += Time.deltaTime * dropSpeed;
                yield return null;
            }
        }
        IEnumerator AnimationScale()
        {
            float time = 0.0f;
            while (time < 1)
            {
                clawWire.transform.localScale = Vector3.Lerp(BeginWireScale, EndWireScale, time);
                time += Time.deltaTime * dropSpeed;
                yield return null;
            }
        }
        IEnumerator AnimationDiamond()
        {
            float time = 0.0f;
            while (time < 1)
            {
                claw.transform.position = Vector3.Lerp(BeginDiamondPosition, EndDiamondPosition, time);
                time += Time.deltaTime * dropSpeed;
                yield return null;
            }
        }
    }
}
