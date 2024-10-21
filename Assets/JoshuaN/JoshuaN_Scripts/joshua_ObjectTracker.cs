using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshua_ObjectTracker : MonoBehaviour
{
    [Header("Movement Settings")]
    public string targetTag = "Target"; 
    public float moveSpeed;
    public float upTime;

    private GameObject targetObject; 
    private joshua_GameManager gameManager;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        gameManager = FindObjectOfType<joshua_GameManager>();

        if (targetObject == null)
        {
            Debug.LogWarning("there is no object with the tag");
            return;
        }

        StartCoroutine(DestroyAfterTime(upTime));

    }

    void Update()
    {
        if (targetObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.1f)
            {
                TargetCollision();      
            }
        }
    }

    void TargetCollision()
    {
        gameManager.UpdateHealth(-1);
        gameManager.ResetCombo();

        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}


