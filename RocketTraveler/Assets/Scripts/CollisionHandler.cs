using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem particleSuccess;
    [SerializeField] ParticleSystem particleCrash;
    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update() 
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            LoadNextLevel(); // załaduj następny poziom
        }
        else if(Input.GetKeyDown(KeyCode.F11))
        {
            collisionDisabled = !collisionDisabled; // Przełącz kolizję
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled) { return; }
        
        switch (other.gameObject.tag)  
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccesSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccesSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        //todo add particle effect upon success
        particleSuccess.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
        audioSource.Stop();
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        //todo add particle effect upon crash
        particleCrash.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
