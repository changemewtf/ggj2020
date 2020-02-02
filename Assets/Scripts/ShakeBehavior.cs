using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
     // Transform of the GameObject you want to shake
    private Transform transform;
    
    // Desired duration of the shake effect
    private float shakeDuration = 0f;
    
    // A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.7f;
    
    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;
    private bool shaking = false;
    
    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent<Transform>();
        }
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    public void StopShake()
    {
        if(shaking)
        {
            shakeDuration = 0f;
            shaking =false;
        }
    }
    public void TriggerShake() {
        if(!shaking)
        {
            // print("SHAKING!");
            shakeDuration = 2.0f;
            shaking = true;
        }
    }
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shaking =false;
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}
