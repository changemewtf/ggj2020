using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopCollisionController : MonoBehaviour
{
    // init
    public GameObject plane;
    public GameObject pigeon;
    private int contactCount = 0;
    public Vector3 pigeon_last_position;

    

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        pigeon = GameObject.Find("Pigeon");
        gameObject.transform.position = pigeon.transform.position;
        
    }

    void OnCollisionEnter(Collision collision)
    {   
        contactCount++;
        
        if(contactCount < 2) {
            if(collision.gameObject.name == "Plane") {
                // Debug.Log(poop.GetComponent<Animation>());
                gameObject.GetComponent<Animation>().Play("Sphere|SphereAction");
                DestroyObjectDelayed();
            }
        }
        // Debug.Log(contactCount);

        
        // Debug.Log(collision.gameObject.name);
    }
    // Update is called once per frame
    void Update()
    {
        pigeon_last_position = pigeon.transform.position;
        
        // Debug.Log(pigeon_last_position);
        
    }


    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 2);
    }
}
