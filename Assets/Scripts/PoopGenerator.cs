using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopGenerator : MonoBehaviour
{
    public bool random;
    public Transform bird_transform;
    public GameObject OldPoop;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        float rgn_poop = Random.Range(0.0f, 50.0f);
        if (random && rgn_poop < 1.0f)
        {
            MakePoop();
        }
    }

    public void MakePoop()
    {
        Instantiate(OldPoop, bird_transform.position, Quaternion.identity);
    }
}
