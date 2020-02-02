using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DriveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float weight = 1.0f;
    public float MaxVelocity = 100;
    public float Mass = 50;
    public float Friction = .05f;
    public bool RotateSprite = true;
    [HideInInspector]
    public Vector2 CurrentVelocity;
  
    Vector3 currentEulerAngles;
    Transform target;
    Transform targetGroup;
    void Start()
    {
        targetGroup= GameObject.Find("TargetGroup").GetComponent<Transform>();
        target = GameObject.Find("Target").GetComponent<Transform>();
    }
    public Vector2 Thrust()
    {
        return CurrentVelocity*30f;
    }
    public Vector2 GetVelocity()
    {
        Vector3 worldpos = target.TransformPoint(Vector3.zero);
        Vector2 target_world = new Vector2(worldpos.x,worldpos.z);
        // print("World pos: "+worldpos+" adjusted: "+target_world);

        Vector2 current_vel = new Vector2(CurrentVelocity.x,CurrentVelocity.y);
        // print("Current Vel "+CurrentVelocity+" Adjusted "+current_vel);
        
        Vector2 current_pos = new Vector2(transform.position.x,transform.position.z);

        // Vector2 headed = current_pos-current_vel;
        Vector2 steering = target_world-current_pos;

        float angle= Vector2.Angle(steering,current_vel);
        print("Difference ange: "+angle);
        // print("Current Pos "+transform.position+" Adjusted "+current_pos);

        Vector2 final_velocity = ((target_world-current_pos).normalized*MaxVelocity)-current_vel;
        print("Final vel: "+final_velocity.magnitude);
        return final_velocity;
        // return ((TargetPoint - (Vector2)transform.position).normalized * agent.MaxVelocity) - agent.CurrentVelocity;  
        // return Vector2.zero;
        // return ((w - (Vector2)transform.position).normalized * MaxVelocity) - v;   
    }
    // void Update()
    // {
    //     Vector2 acceleration = Vector2.zero;

        
    //     float dir = Input.GetAxis("Horizontal");
    //     //modifying the Vector3, based on input multiplied by speed and time
    //     currentEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * dir*100;

    //     //apply the change to the gameObject
    //     targetGroup.eulerAngles = currentEulerAngles;
    //     acceleration += Thrust() * 1f;
    //     acceleration += GetVelocity() * .5f;

    //     CurrentVelocity += acceleration / Mass;

    //     CurrentVelocity -= CurrentVelocity * Friction;

    //     if (CurrentVelocity.magnitude > MaxVelocity)
    //         CurrentVelocity = CurrentVelocity.normalized * MaxVelocity;

    //     Vector3 vel = new Vector3(CurrentVelocity.x,0,CurrentVelocity.y);
    //     transform.position = transform.position + vel * Time.deltaTime;
    
    //     // // if (RotateSprite && CurrentVelocity.magnitude > 0.0001f)
    //     // // {
    //     // //     float angle = Mathf.Atan2(CurrentVelocity.y, CurrentVelocity.x) * Mathf.Rad2Deg;

    //     // //     transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    //     // // }
    // }
    
}
