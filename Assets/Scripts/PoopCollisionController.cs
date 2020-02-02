using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopCollisionController : MonoBehaviour
{
    // init
    public GameObject poop;
    public GameObject plane;
    public GameObject pigeon;
    private int contactCount = 0;
    public Vector3 pigeon_last_position;
    // private PoopGenerato
    public GameObject AvoTree;
    public GameObject AppleTree;
    public GameObject OrangeTree;
    public GameObject PearTree;
    public Vector3 TreePosition;
    

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        // pigeon = GameObject.Find("Pigeon");
        // plane = GameObject.Find("Terrain_2");
        pigeon = GameObject.Find("Rainbow@Glide");
        gameObject.transform.position = pigeon.transform.position;
        TreePosition = new Vector3(pigeon.transform.position.x, 0.0f, pigeon.transform.position.z);
        //Debug.Log(TreePosition);
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

                Instantiate(pickTree(), TreePosition, Quaternion.identity);
                Destroy(gameObject, 1);
            }
            else {
                Destroy(gameObject);
            }
        }
        // Debug.Log(contactCount);

        
        // Debug.Log(collision.gameObject.name);
    }

    private GameObject pickTree(){
        int tree = Random.Range(1, 5);
        // Debug.Log("pick a tree");
        // Debug.Log(tree);
        if(tree==1) {return AppleTree;}
        else if(tree==2){return AvoTree;}
        else if(tree==3){return OrangeTree;}
        else{return PearTree;}
    }
}
