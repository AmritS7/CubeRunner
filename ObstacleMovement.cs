using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public Rigidbody rbo;
    public Transform tr;
    public MeshRenderer renderer;

    public float sideSpeed = 10f;//Move Side    
    bool status= false; //Status
    public float limit = 6f; //Limit
   
    void Start(){
    status = true;
}

void FixedUpdate()
{
        Vector3 obst = renderer.bounds.size;

        
            if (transform.position.x + obst.x / 2 > limit)
            {
                status = false;
            }
            if (transform.position.x - obst.x / 2 < -limit)
            {
                status = true;
            }
            if (status == true)
            {
                transform.Translate(sideSpeed * Time.deltaTime, 0, 0);
            }
            if (status == false)
            {
                transform.Translate(-sideSpeed * Time.deltaTime, 0, 0);
            }
        
}
}
