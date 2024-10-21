using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Wilfreddy : MonoBehaviour
{

    public Transform rotateCenter;

    public float rotateRadius = 2f, angSpeed = 2f;

    float posX, posY, angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = rotateCenter.position.x + Mathf.Cos (angle) * rotateRadius;
        posY = rotateCenter.position.y + Mathf.Sin (angle) * rotateRadius;
        transform.position = new Vector2 (posX, posY);
        angle = angle + Time.deltaTime * angSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
