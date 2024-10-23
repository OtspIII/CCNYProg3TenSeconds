using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonspawner_rey : MonoBehaviour
{
    public GameObject buttonprefab;

    public Vector3 center;
    public Vector3 size;

    public float timebetweenclicks;

    //public bool countup;

    public bool isRunning = false;

    void Update()
    {
        Vector3 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousepos2d = new Vector2(Mousepos.x, Mousepos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousepos2d, Vector2.zero);


        if (hit.collider != null)
        {
            if (hit.collider.tag == "buttoninst")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SpawnNext();

                }
            }
        }


    }

    public void SpawnNext()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            0);
        Instantiate(buttonprefab, pos, Quaternion.identity);

        Destroy(gameObject);




    }
}
