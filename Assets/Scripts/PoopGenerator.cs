using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopGenerator : MonoBehaviour
{
    public Transform bird_transform;
    public GameObject poop;

    // Start is called before the first frame update
    void Start()
    {
            bird_transform = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float rgn_poop = Random.Range(0.0f, 50.0f);
        if(rgn_poop < 1.0f) {
            MakePoop();
        }

    }

    public void MakePoop() {
        Instantiate(poop, bird_transform.position, Quaternion.identity);
    }

}
