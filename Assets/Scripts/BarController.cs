using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
        // SetSize(0.4f);
    }
    public void SetSize(float sizeNormalized)
    {
        bar.transform.localScale =  new Vector3(sizeNormalized,1f);
        // bar.localScale = new Vector3(sizeNormalized,1f);
    }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BirdTummyBar : MonoBehaviour
// {
//     public GameObject TheBar;
//     //private Transform bar;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         // bar = transform.Find("Bar");
//         // // bar.localScale = new Vector3(.4f,1f);
//         // // SetSize(.4f);
        
//     }
//     public void SetSize(float sizeNormalized)
//     {
//         TheBar.transform.localScale =  new Vector3(sizeNormalized,1f);
//         // bar.localScale = new Vector3(sizeNormalized,1f);
//     }
//     // // Update is called once per frame
//     // void Update()
//     // {
        
//     // }
// }
