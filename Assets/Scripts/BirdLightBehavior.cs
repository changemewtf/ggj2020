using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLightBehavior : MonoBehaviour
{
    public Transform BirdTransform;
    public float height;
    private Transform _ligthTransform;
    // Start is called before the first frame update
    void Start()
    {
        _ligthTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _ligthTransform.position = new Vector3(BirdTransform.position.x,BirdTransform.position.y+height,BirdTransform.position.z);
        
    }
}
