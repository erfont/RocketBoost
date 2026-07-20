using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float ThrustForce = 1000;
    [SerializeField] float RotationStrength = 20;
    [SerializeField] AudioClip mainEngineSFX;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem RightThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            ApplyRotation(RotationStrength);
        }
        else if (rotationInput > 0) ApplyRotation(-RotationStrength);
        else
        {
            RightThrustParticles.Stop();
            LeftThrustParticles.Stop();
        }
    }

    private void ApplyRotation(float RotationStrength)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationStrength * Time.fixedDeltaTime);
        rb.freezeRotation = false;
        if (RotationStrength > 0)  
        {
            if (!RightThrustParticles.isPlaying) RightThrustParticles.Play();
        }
        else if (!LeftThrustParticles.isPlaying) LeftThrustParticles.Play();

    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed()) 
        {
            rb.AddRelativeForce(Vector3.up * ThrustForce * Time.fixedDeltaTime);
            if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngineSFX);
            if (!mainEngineParticles.isPlaying) mainEngineParticles.Play();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }
}
