using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshua_PlayerController : MonoBehaviour
{
    public Animator animator;

    [Header("HitBox Settings")]
    public GameObject hitBox;
    public GameObject duckBox;
    public GameObject spinBox;
    public float hitBoxDuration;


    private bool isActionInProgress = false;

    void Update()
    {

        if (isActionInProgress) return;


        if (Input.GetMouseButtonDown(0)) 
        {
           animator.SetTrigger("Hit");
           StartCoroutine(ToggleObjectHitBox());
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Spin");
            StartCoroutine(ToggleObjectSpinBox());

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Duck");
            StartCoroutine(ToggleObjectDuckBox());

        }
    }

    IEnumerator ToggleObjectHitBox()
    {
        isActionInProgress = true;
        hitBox.SetActive(true); 
        yield return new WaitForSeconds(hitBoxDuration); 
        hitBox.SetActive(false); 
        isActionInProgress = false;

    }

    IEnumerator ToggleObjectDuckBox()
    {
        isActionInProgress = true;
        duckBox.SetActive(true); 
        yield return new WaitForSeconds(hitBoxDuration); 
        duckBox.SetActive(false); 
        isActionInProgress = false;

    }

    IEnumerator ToggleObjectSpinBox()
    {
        isActionInProgress = true;
        spinBox.SetActive(true); 
        yield return new WaitForSeconds(hitBoxDuration); 
        spinBox.SetActive(false); 
        isActionInProgress = false;
    }

}
