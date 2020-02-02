using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    // public KeyCode kcNegative = KeyCode.A;
    // public KeyCode kcPositive = KeyCode.D;
    // public Vector3 v3Rotation = new Vector3(0.0f, 0.0f, 1.0f);
    // private float bankAmount;
 
    // void Start()
    // {
    //     bankAmount = 0.0f;
    // }
    // The target marker.
    // public Transform target;

    // Angular speed in radians per sec.
    public float speed = 1.0f;
    // Determine which direction to rotate towards
    void Update()
    {
        // Vector3 targetDirection = target.position - transform.position;
        Vector3 targetDirection = new Vector3(1f,0,0)*Input.GetAxis("Horizontal");

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    // void Update () {

    //     // float hors  = Input.GetKey("Hori")
    //     // float h = -Input.GetAxis("Horizontal");
    //     bankAmount-=0.1f*Input.GetAxis("Horizontal");
    //     bankAmount = Mathf.Lerp(bankAmount,0.0f,Time.deltaTime*2.0f);
    //     print("Bank: "+bankAmount);
    //     // Vector3 p = transform.position;

    //     // p  -=  Vector3.right * h;
    //     // transform.position =p;
    //     transform.rotation *= Quaternion.AngleAxis (bankAmount, Vector3.forward);



    //     // if (Input.GetKey(kcPositive))
    //     //     transform.Rotate (v3Rotation);
    //     // if (Input.GetKey (kcNegative))
    //     //     transform.Rotate (-v3Rotation);
    // }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
