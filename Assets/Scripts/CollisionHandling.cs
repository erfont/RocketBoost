using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandling : MonoBehaviour
{
    [SerializeField] float LevelLoadTimeLapse = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }
    void OnCollisionEnter(Collision other)
    {
        if (!isControllable) return;
        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I collided with a Friend");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();                
                break;

        }
        
    }

    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LevelLoadTimeLapse);       
    }

    private void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadTimeLapse);
    }

    void LoadNextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene((CurrentScene+1) % SceneManager.sceneCountInBuildSettings);
    }
    void ReloadLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
}
