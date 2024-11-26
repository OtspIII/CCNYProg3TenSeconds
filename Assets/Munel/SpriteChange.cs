using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer Chicken1;
    public Sprite hurt;
    // Start is called before the first frame update
    void Start()
    {
        Chicken1.sprite = hurt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
