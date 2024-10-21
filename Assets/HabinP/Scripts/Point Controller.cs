using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public Transform BluePoint1;
    public Transform BluePoint2;

    public Transform YellowPoint1;
    public Transform YellowPoint2;

    public Transform RedPoint1;
    public Transform RedPoint2;

    public Transform LeftBottomPoint;
    public Transform RightBottomPoint;
    public Transform LeftTopPoint;
    public Transform RightTopPoint;

    public float Speed = 1.0f;
    float randomNumberBlue;
    float randomNumberYellow;
    float randomNumberRed;

    int DirectionBlue = 1;
    int DirectionYellow = -1;
    int DirectionRed = 1;
    // Start is called before the first frame update
    void Start()
    {
        randomNumberBlue = Random.Range(1, 10);
        randomNumberYellow = Random.Range(1, 10);
        randomNumberRed = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetBlue = currentMovementTargetBlue();
        Vector2 targetYellow = currentMovementTargetYellow();
        Vector2 targetRed = currentMovementTargetRed();


        BluePoint1.position = Vector2.Lerp(BluePoint1.position, targetBlue, randomNumberBlue * Time.deltaTime);
        float distanceBlue = (targetBlue - (Vector2)BluePoint1.position).magnitude;
        if (distanceBlue < 0.1f)
        {
            DirectionBlue *= -1;
            randomNumberBlue = Random.Range(1, 10);

        }

        YellowPoint1.position = Vector2.Lerp(YellowPoint1.position, targetYellow, Time.deltaTime * randomNumberYellow);
        float distanceYellow = (targetYellow - (Vector2)YellowPoint1.position).magnitude;
        if (distanceYellow < 0.1f)
        {
            DirectionYellow *= -1;
            randomNumberYellow = Random.Range(1, 10);

        }
        RedPoint1.position = Vector2.Lerp(RedPoint1.position, targetRed, Time.deltaTime * randomNumberRed);
        float distanceRed = (targetRed - (Vector2)RedPoint1.position).magnitude;
        if (distanceRed < 0.1f)
        {
            DirectionRed *= -1;
            randomNumberRed = Random.Range(1, 10);

        }
    }
    Vector2 currentMovementTargetBlue()
    {
        if (DirectionBlue == 1) 
        {
            return RightBottomPoint.position;
        }
        else
        {
            return LeftBottomPoint.position;
        }

    }
    Vector2 currentMovementTargetYellow()
    {
        if (DirectionYellow == 1)
        {
            return RightBottomPoint.position;
        }
        else
        {
            return LeftBottomPoint.position;
        }

    }
    Vector2 currentMovementTargetRed()
    {
        if (DirectionRed == 1)
        {
            return RightBottomPoint.position;
        }
        else
        {
            return LeftBottomPoint.position;
        }

    }

}
