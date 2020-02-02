// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Mover : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private Rigidbody body;
//     void Start()
//     {
//         body = transform.GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float dir = Input.GetAxis("Horizontal");
//         // float step = dir*Time.deltaTime+100;
//         // print("STEP: "+step);
//         Vector3 dir = Quaternion.Euler(dir*Time.deltaTime, 0, 0)*transform.forward;

//         // Vector3 justAhead = (transform.forward*10+transform.right*dir).normalized;
//         // // print("AHEAD "+justAhead);
//         // Vector3 ahead=Vector3.RotateTowards(transform.forward,justAhead,Time.deltaTime*100,0.0f);
//         // print("Ahead is "+ahead);
//     }
// }
using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Rigidbody rb;

    void Awake()
    {
        // Creates the floor.
        GameObject floor  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.localScale = new Vector3(6.0f, 1.0f, 6.0f);
        floor.transform.position = new Vector3(0.0f, -0.5f, 0.0f);

        Material matColor = new Material(Shader.Find("Standard"));
        matColor.color = new Color32(32, 32, 128, 255);
        floor.GetComponent<Renderer>().material = matColor;

        transform.position = new Vector3(-3.0f, 0.0f, 0.0f);

        Camera.main.transform.position = new Vector3(6.0f, 4.0f, 6.0f);
        Camera.main.transform.localEulerAngles = new Vector3(26.0f, -135.0f, 0.0f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Moves the GameObject using it's transform.
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        // // Moves the GameObject to the left of the origin.
        // if (transform.position.x > 3.0f)
        // {
        //     print("Reset?");
        //     transform.position = new Vector3(-3.0f, 0.0f, 0.0f);
        // }
        float h = Input.GetAxis("Horizontal");
        rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime*h);
    }
}