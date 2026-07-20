using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandling : MonoBehaviour
{
    [SerializeField] float LevelLoadTimeLapse = 2f;
    void OnCollisionEnter(Collision other)
    {
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
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LevelLoadTimeLapse);       
    }

    private void StartCrashSequence()
    {
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
