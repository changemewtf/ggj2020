using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float thrust = 1.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi I'm a birt");
        rb = GetComponent<Rigidbody>();
    }

    // Physics updates go in FixedUpdate() instead of Update()!
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * thrust);
        }
    }
}
