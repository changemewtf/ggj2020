using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float FlapThrust = 30.0f;
    public float ForwardThrust = 20.0f;

    private Rigidbody rb;
    private Animator anim;
    private bool flapping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
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
            //anim.SetTrigger("Flap");
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

    void OnTriggerEnter(Collider collid)
    {
        if (collid.gameObject.CompareTag("Pickupabble"))
        {
            Debug.Log("Picked up a " + collid.gameObject.name);
            Destroy(collid.gameObject);
        }
    }
}
