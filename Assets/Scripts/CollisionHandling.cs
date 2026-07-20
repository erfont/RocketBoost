using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandling : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I collided with a Friend");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;

        }

        void LoadNextLevel()
        {
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Number of scenes" + SceneManager.sceneCount);
            Debug.Log("Current scene " + CurrentScene);
            Debug.Log("Calculation " + (CurrentScene+1) % SceneManager.sceneCountInBuildSettings);
            SceneManager.LoadScene((CurrentScene+1) % SceneManager.sceneCountInBuildSettings);
        }
        void ReloadLevel()
        {
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CurrentScene);
        }
    }
}
