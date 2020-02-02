using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowUpdater : MonoBehaviour
{
    public List<GameObject> FollowTargets;
    public CinemachineVirtualCamera Cam;

    private GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        Pop();
        //Cam = GetComponent<CinemachineVirtualCamera>();
    }

    void Pop()
    {
        Target = FollowTargets[0];
        Cam.LookAt = Target.transform;
        FollowTargets.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Pop();
        }
    }
}
