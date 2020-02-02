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
        //TODO: change this to allow both auto poop based on 
        float rgn_poop = Random.Range(0.0f, 100.0f);
        if(rgn_poop < 1.0f) {
            MakePoop();
        }

    }

    public void MakePoop() {
        Instantiate(poop, new Vector3(bird_transform.position.x, bird_transform.position.y - 300.0f, bird_transform.position.z), Quaternion.identity);
    }

}
