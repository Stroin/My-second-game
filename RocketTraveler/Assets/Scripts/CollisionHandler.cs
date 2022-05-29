using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
     void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)  
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("This is finish");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
