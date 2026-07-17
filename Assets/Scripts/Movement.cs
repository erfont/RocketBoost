using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float ThrustForce = 1000;
    [SerializeField] float RotationStrength = 20;
    Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1;
    }

    private void OnEnable() 
    {
        thrust.Enable();    
        rotation.Enable();
    }

    void Update()
    {
    }

// Updates made to physics are preferrable in FixedUpdate rather than in Update
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            transform.Rotate(Vector3.forward * RotationStrength * Time.fixedDeltaTime);
        }
        else if (rotationInput > 0) transform.Rotate(Vector3.back * RotationStrength * Time.fixedDeltaTime);
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed()) rb.AddRelativeForce(Vector3.up * ThrustForce * Time.fixedDeltaTime);
    }
}
