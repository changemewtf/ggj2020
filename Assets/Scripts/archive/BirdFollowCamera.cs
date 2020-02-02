using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollowCamera : MonoBehaviour
{
    public Transform BirdTransform;
    private Transform _cameraOffset;
    public float glideDistance;
    public float climbDistance;
    public float height;
    
    // private Transform transform;

    // [Range(0.01f,1.0f)]
    // public float smoothFactor = 0.5f;

    
    // Start is called before the first frame update
    void Start()
    {
        // transform = GetComponent<Transform>();
        // _cameraOffset = transform.position = BirdTransform.position;
        _cameraOffset = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Vector3 newPos = BirdTransform.position + _cameraOffset;
        // transform.position = Vector3.Slerp(transform.position,newPos,smoothFactor);
        
        _cameraOffset.position = new Vector3(BirdTransform.position.x,BirdTransform.position.y+height,BirdTransform.position.z-glideDistance);
        transform.LookAt(BirdTransform);
    }
}
