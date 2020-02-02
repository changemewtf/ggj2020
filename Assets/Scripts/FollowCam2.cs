using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam2 : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 4.0f;
    public float offsetx = 4.0f;
    // var distance = 5.0;
    // var height = 4.0;
    
    public float rotationDamping = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate () {
        if (!target)
            return;
        
        float wantedRotationAngleSide = target.eulerAngles.y;
        float currentRotationAngleSide = transform.eulerAngles.y;
    
        float wantedRotationAngleUp = target.eulerAngles.x;
        float currentRotationAngleUp = transform.eulerAngles.x;
    
        currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, rotationDamping * Time.deltaTime);
    
        currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, rotationDamping * Time.deltaTime);
    
        Quaternion currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);
    
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
    
        transform.LookAt(target);
    
        transform.position += transform.up * height;
        transform.position += transform.right * offsetx;


    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}


 
 
