using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float FlapThrust = 30.0f;
    public float ForwardThrust = 20.0f;

    private bool flapping;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi I'm a birt");
        rb = GetComponent<Rigidbody>();
        flapping = false;
    }

    private void Update()
    {
        // In Unity documentation, Input goes in FixedUpdate(), but we're going
        // to put it in Update() here because we don't want to drop any inputs.
        // If it's in FixedUpdate(), then slower machines might miss some inputs
        // because they do not have the power to calculate as many ticks.
        if (Input.GetKeyDown("space"))
        {
            flapping = true;
        }
    }

    // Physics updates go in FixedUpdate() instead of Update()!
    void FixedUpdate()
    {

        rb.AddForce(transform.forward * ForwardThrust);

        if (flapping) {
            rb.AddForce(transform.up * FlapThrust, ForceMode.Impulse);
            flapping = false;
        }
    }
}
