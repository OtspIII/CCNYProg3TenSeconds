using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshua_DuckBoxDetect : MonoBehaviour
{
    [Header("Collision Settings")]
    public float moveSpeed;
    public float moveDistance;

    private joshua_GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<joshua_GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DuckObject"))
        {
            joshua_ObjectTracker objectTrackerScript = other.GetComponent<joshua_ObjectTracker>();

            if (objectTrackerScript != null)
            {
                objectTrackerScript.enabled = false; 
            }

            gameManager.UpdateCombo(1);

            StartCoroutine(Dodge(other.transform));
        }
    }

    IEnumerator Dodge(Transform objectTransform)
    {
        float startXPosition = objectTransform.position.x; 

        while (true)
        {
            objectTransform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

            if (objectTransform.position.x >= startXPosition + moveDistance)
            {
                Destroy(objectTransform.gameObject); 
                yield break; 
            }

            yield return null; 
        }
    }
}
