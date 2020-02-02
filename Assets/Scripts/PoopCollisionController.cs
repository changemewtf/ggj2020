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
    // private PoopGenerato
    public GameObject AvoTree;
    public GameObject AppleTree;
    public GameObject OrangeTree;
    public GameObject PearTree;
    

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        pigeon = GameObject.Find("Pigeon");
        gameObject.transform.position = pigeon.transform.position;
        contactCount = 0;
        // poog = pigeon.GetComponent<PoopGenerator>();
        
    }
    void OnCollisionEnter(Collision collision)
    {   
        contactCount++;
        // Debug.Log(contactCount);
        
        if(contactCount > 0) {

            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.name == "Plane") {
                //TODO: make the animation work.
                // Debug.Log("ground hit!");
                Instantiate(pickTree(), gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject, 2);
            }
        }
        // Debug.Log(contactCount);

        
        // Debug.Log(collision.gameObject.name);
    }
    // Update is called once per frame
    void Update()
    {
        pigeon_last_position = pigeon.transform.position;
        
    }

    private GameObject pickTree(){
        int tree = Random.Range(1, 5);
        Debug.Log("pick a tree");
        Debug.Log(tree);
        if(tree==1) {return AppleTree;}
        else if(tree==2){return AvoTree;}
        else if(tree==3){return OrangeTree;}
        else{return PearTree;}

        return AppleTree;
        
    }
}
