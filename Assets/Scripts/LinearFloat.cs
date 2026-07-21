using System;
using UnityEngine;

public class LinearFloat : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] private float period = 5f;

    [SerializeField] AnimationCurve speedCurve;

    Vector3 startPos, targetPos;

    void Start()
    {
        startPos = transform.position;
        targetPos = target.transform.position;
        
    }

    void Update()
    {
      // Vector3 newPos = Vector3.Lerp(startPos, targetPos, Mathf.PingPong(Time.time, 1f));

       Vector3 newPos = Vector3.Lerp(startPos, targetPos, speedCurve.Evaluate(Time.time/period));

       transform.position = newPos;

        if (newPos.Equals(targetPos))
            SwapPositions(newPos);
    }

    private void SwapPositions(Vector3 newPos)
    {
        targetPos = startPos;
        startPos = newPos;
    }
}
