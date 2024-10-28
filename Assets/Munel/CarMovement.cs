using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    void Update()
    {
        if (Time.time > 3f)
        transform.Translate(-10f * Time.deltaTime, 0, 0);
    }
}
