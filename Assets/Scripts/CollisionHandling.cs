using UnityEngine;

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
                Debug.Log("I reached the end");
                break;
            default:
                Debug.Log("I collided with something else");
                break;

        }
    }
}
