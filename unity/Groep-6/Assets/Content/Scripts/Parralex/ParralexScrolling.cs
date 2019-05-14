using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralexScrolling : MonoBehaviour
{
    [SerializeField]
    //Start position of the clouds
    Vector3 startPosition;
    [SerializeField]
    //Speed of the clouds moving
    float movingSpeed;
    [SerializeField]
    //The position the parralex should 'reset'
    float reset;

    void Start()
    {
        movingSpeed = 2f;
        startPosition = transform.position;
        reset = 19.25f;
    }
    
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * movingSpeed, reset);
        transform.position = (startPosition + Vector3.left) * newPosition;
    }
}
