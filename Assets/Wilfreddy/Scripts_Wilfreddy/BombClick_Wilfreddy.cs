using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombClick_Wilfreddy : MonoBehaviour
{

    // Collider 2D attached to this GameObject

    private Collider2D myCollider;

    public GameObject Yay;
    public GameObject Canvas;
    public GameObject Confetti;

    
    public GameObject Timer;

    void Start()
    {
        Yay.SetActive(false);
        Canvas.SetActive(false);
        Confetti.SetActive(false);

        myCollider = GetComponent<Collider2D>();

    }



    void OnMouseDown()
    {

        // Check if mouse click is within the collider bounds

        if (myCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))

        {
            Yay.SetActive(true);
            Canvas.SetActive(true);
            Confetti.SetActive(true);

            
            Timer.SetActive(false);

            
            StartCoroutine(Switching());
        }

    }

    IEnumerator Switching()
    {
        yield return new WaitForSeconds(6f);
        GameMaster.NextStage();

    }
}
