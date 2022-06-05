using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotation = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem particleEngine;
    [SerializeField] ParticleSystem particleEngineLeft;
    [SerializeField] ParticleSystem particleEngineRight;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
   
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if(!audioSource.isPlaying)
            {
            audioSource.PlayOneShot(mainEngine);
            }
            if(!particleEngine.isPlaying)
            {
                particleEngine.Play();
            }
        }
        else
        {
            audioSource.Stop();
            particleEngine.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApllyRotation(mainRotation);
            if(!particleEngineLeft.isPlaying)
            {
                particleEngineLeft.Play();
            }
            else
            {
                particleEngineLeft.Stop();
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApllyRotation(-mainRotation);
           if(!particleEngineRight.isPlaying)
            {
                particleEngineRight.Play();
            }
            else
            {
                particleEngineRight.Stop();
            }
        }
    }

    private void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // zamrażanie rotacji, dzięki czemu możemy ręcznie obracać
        transform.Rotate(Vector3.forward * rotationThisFrame * mainRotation);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }
}
