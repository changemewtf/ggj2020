using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBankTop : MonoBehaviour
{
    // Start is called before the first frame update
    // private Rigidbody rigid;
    // private Transform heading;
    void Start()
    {
        // rigid = transform.GetComponent<Rigidbody>();
        // heading = transform.Find("HeadingCube");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        // Ultra simple flight where the plane just gets pushed forward and manipulated
        // with torques to turn.
        // rigid.AddRelativeForce(Vector3.forward * 30, ForceMode.Force);
        // float h = Input.GetAxis("Horizontal");
        // rigid.AddRelativeForce(Vector3.right*100*h,ForceMode.Force);
        // rigid.AddRelativeTorque(new Vector3(turnTorque.x * pitch,
        //                                     turnTorque.y * yaw,
        //                                     -turnTorque.z * roll) * forceMult,
        //                         ForceMode.Force);
    }
}
