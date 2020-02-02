using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Steer2D.Seek AgentSeek;
    // Start is called before the first frame update
    void Start()
    {
        if (AgentSeek != null)
            AgentSeek.TargetPoint = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
