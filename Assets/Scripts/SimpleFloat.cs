using UnityEngine;

public class SimpleFloat : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f; // how far it moves up/down
    [SerializeField] private float frequency = 1f;    // how fast it moves

    [SerializeField] AnimationCurve frequencyCurve;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // // Calculating newY via Sin function
        // float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        
        // Calculating newY via AnimationCurve
        float newY = startPos.y + frequencyCurve.Evaluate(Time.time * frequency) * amplitude;

        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
