using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 tempVec3 = new Vector3();
    public Transform target;
    public int offset;
    void Start()
    {
        
    }
    void Update()
    {
        tempVec3.x = this.transform.position.x;
        tempVec3.y = this.transform.position.y;
        tempVec3.z = target.position.z - offset;
        this.transform.position = tempVec3;
    }
}
