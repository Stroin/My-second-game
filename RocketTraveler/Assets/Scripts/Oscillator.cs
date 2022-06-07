using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    float movementFactor;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }; // nie wyświetla błędu spowodowane dzielieniem przez 0
        float cycles = Time.time /  period; // rośnie z czasem
        
        const float tau = Mathf.PI * 2; // stała wartość 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // przechodzi z -1 do 1

        movementFactor = (rawSinWave + 1f) / 2f; // oblicza od do z 0 do 1,

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
