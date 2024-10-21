using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshua_HitBoxDetect : MonoBehaviour
{
    [Header("Collision Settings")]
    public float moveSpeed;
    public float destroyAfterSeconds;
    public float moveDistance;

    private joshua_GameManager gameManager;

    public AudioSource hitSound;

    void Start()
    {
        gameManager = FindObjectOfType<joshua_GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitObject"))
        {
            joshua_ObjectTracker objectTrackerScript = other.GetComponent<joshua_ObjectTracker>();

            if (objectTrackerScript != null)
            {
                objectTrackerScript.enabled = false; 
            }

            gameManager.UpdateCombo(1);
            
            StartCoroutine(HitUp(other.transform));
        }
    }

    IEnumerator HitUp(Transform objectTransform)
    {
        hitSound.Play();
        float startYPosition = objectTransform.position.y; 

        while (true)
        {
            objectTransform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

            if (objectTransform.position.y >= startYPosition + moveDistance)
            {
                Destroy(objectTransform.gameObject); 
                yield break;
            }

            yield return null; 
        }
    }
}
